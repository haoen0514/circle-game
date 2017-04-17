class Circle {
  float sz;
  float angle = 0;
  float mA;
  boolean mouseIn = false;
  int division = 8;

  ArrayList<Bullet> bullets;

  Circle(float _sz) {
    sz = _sz;
    bullets = new ArrayList<Bullet>();
  }

  void update() {
    angle = millis() / 1000.0;
    if (angle > 2 * PI) {
      angle -= 2 * PI;
    }
  }

  void render() {
    pushMatrix();

    translate(width / 2, height / 2);
    drawMainCircle();
    drawLine();
    drawOutCircle();
    drawBullets();
    popMatrix();
  }

  // draw
  void drawMainCircle() {
    stroke(colOfLine);
    strokeWeight(2);
    fill(colOfCircle);
    ellipse(0, 0, sz, sz);
  }
  void drawLine() {
    stroke(colOfLine);
    strokeWeight(4);
    float xpos =  sz / 2 * cos(angle);
    float ypos =  sz / 2 * sin(angle);
    line(0, 0, xpos, ypos);
    ellipse(0, 0, 20, 20);

    stroke(colOfPoint);
    ellipse(xpos, ypos, 10, 10);
  }
  void drawOutCircle() {
    stroke(colOfOutCircle);
    strokeWeight(2);
    noFill();
    ellipse(0, 0, sz * 1.9, sz * 1.9);
  }
  void drawBullets() {
    for (int i = 0, n = bullets.size(); i < n; i++) {
      bullets.get(i).update();
      bullets.get(i).render();
    }
  }
  // mouse
  void mouseSensed() {
    int mX = mouseX - width / 2;
    int mY = mouseY - height / 2;
    float r2 = mX * mX + mY * mY;
    mA = atan2(mY, mX);

    if (r2 > sq(0.9 * sz / 2) && r2 < sq(1.1 * sz / 2)) {
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

  void mousePressed() {
    if (mouseIn) {
      bullets.add(new Bullet(this, mA));
    }
  }


}
