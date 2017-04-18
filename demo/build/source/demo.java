import processing.core.*; 
import processing.data.*; 
import processing.event.*; 
import processing.opengl.*; 

import oscP5.*; 
import netP5.*; 

import java.util.HashMap; 
import java.util.ArrayList; 
import java.io.File; 
import java.io.BufferedReader; 
import java.io.PrintWriter; 
import java.io.InputStream; 
import java.io.OutputStream; 
import java.io.IOException; 

public class demo extends PApplet {




//oscP5
OscP5 oscP5;
NetAddress other;

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
boolean gameOver = false;
int ptn = 0;

public void setup() {
  
  circle = new Circle(width / 2);

  //oscP5
  oscP5 = new OscP5(this, 12000);
  other = new NetAddress("127.0.0.1", 12001);

  //text
  textAlign(CENTER, BOTTOM);
}


public void draw() {
  if (gameOver) {
    background(colOfCircle);
    fill(colOfLine);
    textSize(64);
    text("Game Over", width / 2, height / 2);
    textSize(32);
    text("press mouse to restart", width / 2, height / 2 + 50);
  } else {
    circle.update();
    circle.render();
    circle.mouseSensed();
  }
}

public void mousePressed() {
  if (!gameOver) {
    circle.mousePressed();
  } else {
    circle = new Circle(width / 2);
    gameOver = false;
  }
}

public void sendOSC(int x) {
  OscMessage msg = new OscMessage("/p5");
  msg.add(x);
  oscP5.send(msg, other);
}

public void keyPressed() {
  if (!gameOver) {
    if (key == 'a') {
      circle.createEnemy();
    }
  } else {
    circle = new Circle(width / 2);
    gameOver = false;
  }

  if (key == '1') {
    triggerPattern(1);
  }
  if (key == '2') {
    triggerPattern(2);
  }
  if (key == '3') {
    triggerPattern(3);
  }
}



public void triggerPattern(int i) {
  ptn = i;
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
        gameOver = true;
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
  float lastAngle = 0;
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
    println("angle:" + angle);
    angle = (millis() / 1000.0f) - lastAngle;
    if (angle > 2 * PI) {
      lastAngle = (millis() / 1000.0f);
      create();
    }

    // createEnemy
    updateIndex();
    clearBullet();
    clearEnemies();
    checkCollision();
  }

  public void create() {
    if (ptn == 1) {
      createEnemy(0);
    }
    if (ptn == 2) {
      createEnemy(0);
      createEnemy(8);
    }
    if (ptn == 3) {
      createEnemy(0);
      createEnemy(4);
      createEnemy(8);
      createEnemy(12);
    }
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
        bullets.add(new Bullet(this, b.angle));
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
  public void createEnemy(int i) {
    enemies.add(new Enemy(this, i % division));
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
          sendOSC(e.index);
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

    position -= 0.2f;
    if (position < circle.sz) {
      live = false;
      gameOver = true;
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
  public void settings() {  size(400, 400); }
  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "demo" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
