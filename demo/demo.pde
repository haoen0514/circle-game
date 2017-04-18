import oscP5.*;
import netP5.*;

//oscP5
OscP5 oscP5;
NetAddress other;

// colors
color colOfBk = color (44, 62, 80);
color colOfCircle = color (51, 110, 123);
// color colOfOutCircle = color (54, 215, 183);
color colOfOutCircle = color (51, 110, 123);
color colOfLine = color (224, 130, 131);
color colOfPoint = color (75, 119, 190);
color colOfBullet = color (249, 105, 14);
color colOfEnemy = color (192, 57, 43);

Circle circle;
boolean gameOver = false;
int ptn = 0;

void setup() {
  size(400, 400);
  circle = new Circle(width / 2);

  //oscP5
  oscP5 = new OscP5(this, 12000);
  other = new NetAddress("127.0.0.1", 12001);

  //text
  textAlign(CENTER, BOTTOM);
}


void draw() {
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

void mousePressed() {
  if (!gameOver) {
    circle.mousePressed();
  } else {
    circle = new Circle(width / 2);
    gameOver = false;
  }
}

void sendOSC(int x) {
  OscMessage msg = new OscMessage("/p5");
  msg.add(x);
  oscP5.send(msg, other);
}

void keyPressed() {
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



void triggerPattern(int i) {
  ptn = i;
}
