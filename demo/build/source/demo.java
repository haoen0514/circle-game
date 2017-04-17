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
}
class Circle {
  float sz;
  float angle = 0;

  Circle(float _sz) {
    sz = _sz;
  }

  public void update() {
    angle += 0.01f;
  }

  public void render() {
    pushMatrix();

    translate(width / 2, height / 2);
    stroke(colOfLine);
    strokeWeight(2);
    fill(colOfCircle);
    ellipse(0, 0, sz, sz);
    drawLine();
    popMatrix();
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
