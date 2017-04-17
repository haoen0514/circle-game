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
int colOfBk = color (30, 30, 30);
int colOfCircle = color (200, 200, 200);
int colOfOutCircle = color (54, 215, 183);
int colOfLine = color (224, 130, 131);
int colOfPoint = color (75, 119, 190);

Circle circle;


public void setup() {
  
  background(colOfBk);
  circle = new Circle(width / 2);
}


public void draw() {
  background(colOfBk);
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

  Circle circle;
  float angle;
  float finalAngle;
  float accel = 0.1f;
  float position;

  Bullet(Circle _c, float _a) {
    circle = _c;
    angle = _a;
    finalAngle = round(_a / (PI / 8)) * (PI / 8);
    position = circle.sz;
  }

  public void update() {
    angle += (finalAngle - angle) * accel;
    if (abs(angle - circle.angle) < 0.1f) {
      flying = true;
    }
    if (flying) {
      position += 2;
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

  }
}
class Circle {
  float sz;
  float angle = 0;
  float mA;
  boolean mouseIn = false;

  ArrayList<Bullet> bullets;

  Circle(float _sz) {
    sz = _sz;
    bullets = new ArrayList<Bullet>();
  }

  public void update() {
    angle = millis() / 1000.0f;
    if (angle > 2 * PI) {
      angle -= 2 * PI;
    }
  }

  public void render() {
    pushMatrix();

    translate(width / 2, height / 2);
    drawMainCircle();
    drawLine();
    drawOutCircle();
    drawBullets();
    popMatrix();
  }

  // draw
  public void drawMainCircle() {
    stroke(colOfLine);
    strokeWeight(2);
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
    stroke(colOfOutCircle);
    strokeWeight(2);
    noFill();
    ellipse(0, 0, sz * 1.9f, sz * 1.9f);
  }
  public void drawBullets() {
    for (int i = 0, n = bullets.size(); i < n; i++) {
      bullets.get(i).update();
      bullets.get(i).render();
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
