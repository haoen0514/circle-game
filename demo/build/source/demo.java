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

Circle circle;


public void setup() {
  
  // background(colOfBk);
  circle = new Circle(width / 2);
}


public void draw() {
  // background(colOfBk);
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
    fill(255, 0, 0);
    stroke(255, 0, 0);
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
  boolean triggering = false;
  int currentIndex;

  Circle(float _sz) {
    sz = _sz;
    outSz = _sz * RATIO;
    bullets = new ArrayList<Bullet>();
  }

  public void update() {
    angle = millis() / 1000.0f;
    if (angle > 2 * PI) {
      angle -= 2 * PI;
    }
    updateIndex();
    clearBullet();
  }

  public void render() {
    background(51, 110, 123);
    pushMatrix();

    translate(width / 2, height / 2);
    drawOutCircle();
    drawMainCircle();
    drawLine();
    drawBullets();
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
