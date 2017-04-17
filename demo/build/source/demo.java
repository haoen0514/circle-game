import processing.core.*; 
import processing.data.*; 
import processing.event.*; 
import processing.opengl.*; 

import java.util.HashMap; 
import java.util.ArrayList; 
import java.io.File; 
import java.io.BufferedReader; 
import java.io.PrintWriter; 
import java.io.InputStream; 
import java.io.OutputStream; 
import java.io.IOException; 

public class demo extends PApplet {

// colors
int colOfBk = color (44, 62, 80);
int colOfCircle = color (51, 110, 123);
// color colOfOutCircle = color (54, 215, 183);
int colOfOutCircle = color (51, 110, 123);
int colOfLine = color (224, 130, 131);
int colOfPoint = color (75, 119, 190);
int colOfBullet = color (249, 105, 14);
int colOfEnemy = color (192, 57, 43);

Circle circle;


public void setup() {
  
  circle = new Circle(width / 2);
}


public void draw() {
  circle.update();
  circle.render();
  circle.mouseSensed();
}

public void mousePressed() {
  circle.mousePressed();
}
class Bullet {

  // states
  boolean flying = false;
  boolean live = true;

  Circle circle;
  float angle;
  float finalAngle;
  float accel = 0.1f;

  int index;
  int division;
  float position;

  Bullet(Circle _c, float _a) {
    circle = _c;
    angle = _a;
    division = circle.division;
    index =  (round(_a / (2 * PI / division)) + division) % division;
    println("ball index:" + index);
    finalAngle = round(_a / (2 * PI / division)) * (2 * PI / circle.division);
    position = circle.sz;
  }

  public void update() {
    angle += (finalAngle - angle) * accel;

    if (flying) {
      position += 2;
      if (position > circle.outSz) {
        live = false;
      }
    }

  }

  public void render() {
    fill(colOfBullet);
    stroke(colOfPoint);
    strokeWeight(4);
    float xpos;
    float ypos;
    if (!flying) {
      xpos = circle.sz * cos(angle) / 2;
      ypos = circle.sz * sin(angle) / 2;
    } else {
      xpos = position * cos(angle) / 2;
      ypos = position * sin(angle) / 2;
    }
    ellipse(xpos, ypos, 10, 10);
  }

  public void trigger() {
    flying = true;
  }
}
final float RATIO = 1.9f;
class Circle {
  float sz;
  float outSz;
  float angle = 0;
  float mA;
  boolean mouseIn = false;
  int division = 16;

  ArrayList<Bullet> bullets;
  ArrayList<Enemy> enemies;
  boolean triggering = false;
  int currentIndex;

  Circle(float _sz) {
    sz = _sz;
    outSz = _sz * RATIO;
    bullets = new ArrayList<Bullet>();
    enemies = new ArrayList<Enemy>();
  }

  public void update() {
    // rotate
    angle = millis() / 1000.0f;
    if (angle > 2 * PI) {
      angle -= 2 * PI;
    }

    // createEnemy
    if (random(1) < 0.002f) {
      createEnemy();
    }

    updateIndex();
    clearBullet();
    clearEnemies();
    checkCollision();
  }

  public void render() {
    background(51, 110, 123);
    pushMatrix();

    translate(width / 2, height / 2);
    drawOutCircle();
    drawMainCircle();
    drawLine();
    drawBullets();
    drawEnemies();
    popMatrix();
  }

  // draw
  public void drawMainCircle() {
    stroke(colOfLine);
    strokeWeight(4);
    fill(colOfCircle);
    ellipse(0, 0, sz, sz);
  }
  public void drawLine() {
    stroke(colOfLine);
    strokeWeight(4);
    float xpos =  sz / 2 * cos(angle);
    float ypos =  sz / 2 * sin(angle);
    line(0, 0, xpos, ypos);
    ellipse(0, 0, 20, 20);

    fill(colOfLine);
    stroke(colOfPoint);
    ellipse(xpos, ypos, 10, 10);
  }
  public void drawOutCircle() {
    stroke(colOfLine);
    strokeWeight(4);
    fill(colOfBk);
    ellipse(0, 0, outSz, outSz);
  }
  public void drawBullets() {
    for (int i = 0, n = bullets.size(); i < n; i++) {
      Bullet b = bullets.get(i);
      b.update();
      b.render();
      if (triggering && b.index == currentIndex) {
        b.trigger();
      }
    }
    triggering = false;
  }
  public void drawEnemies() {
    for (int i = 0, n = enemies.size(); i < n; i++) {
      Enemy e = enemies.get(i);
      e.update();
      e.render();
    }
  }

  // bullets control
  public void updateIndex() {
    int index = floor(angle / (2 * PI / division)) % division; // round -> floor
    if (currentIndex != index) {
      currentIndex = index;
      triggering = true;
    }
  }
  public void clearBullet() {
    for (int i = bullets.size() - 1; i >= 0; i--) {
      Bullet b = bullets.get(i);
      if (!b.live) {
        bullets.remove(b);
      }
    }
  }

  // enemies control
  public void createEnemy() {
    enemies.add(new Enemy(this, floor(random(division))));
  }
  public void clearEnemies() {
    for (int i = enemies.size() - 1; i >= 0; i--) {
      Enemy e = enemies.get(i);
      if (!e.live) {
        enemies.remove(e);
      }
    }
  }

  public void checkCollision() {
    for (int i = enemies.size() - 1; i >= 0; i--) {
      Enemy e = enemies.get(i);
      for (int j = bullets.size() - 1; j >= 0; j--) {
        Bullet b = bullets.get(j);
        if (e.index == b.index && b.position > e.position) {
          e.live = false;
          b.live = false;
        }
      }
    }
  }

  // mouse
  public void mouseSensed() {
    int mX = mouseX - width / 2;
    int mY = mouseY - height / 2;
    float r2 = mX * mX + mY * mY;
    mA = atan2(mY, mX);

    if (r2 > sq(0.9f * sz / 2) && r2 < sq(1.1f * sz / 2)) {
      fill(colOfPoint);
      stroke(colOfPoint);
      float xpos = sz * cos(mA) / 2;
      float ypos = sz * sin(mA) / 2;
      ellipse(width / 2 + xpos, height / 2 + ypos, 10, 10);
      mouseIn = true;
    } else {
      mouseIn = false;
    }
  }
  public void mousePressed() {
    if (mouseIn) {
      bullets.add(new Bullet(this, mA));
    }
  }

}
class Enemy {

  // states
  boolean live = true;

  Circle circle;
  float angle;

  int index;
  int division;
  float position;

  Enemy(Circle _c, int _i) {
    circle = _c;
    division = circle.division;
    index = _i;
    println("enemy index:" + index);
    angle = index * (2 * PI / division);
    position = circle.outSz;
  }

  public void update() {
    // angle += (finalAngle - angle) * accel;

    position -= 0.5f;
    if (position < circle.sz) {
      live = false;
    }
  }

  public void render() {
    fill(colOfEnemy);
    stroke(colOfPoint);
    strokeWeight(4);
    float xpos;
    float ypos;
    xpos = position * cos(angle) / 2;
    ypos = position * sin(angle) / 2;
    ellipse(xpos, ypos, 10, 10);
  }
}
  public void settings() {  size(800, 800); }
  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "demo" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
