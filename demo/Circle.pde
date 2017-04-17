final float RATIO = 1.9;
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

  void update() {
    angle = millis() / 1000.0;
    if (angle > 2 * PI) {
      angle -= 2 * PI;
    }
    updateIndex();
    clearBullet();
  }

  void render() {
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
  void drawMainCircle() {
    stroke(colOfLine);
    strokeWeight(4);
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
    stroke(colOfLine);
    strokeWeight(4);
    fill(colOfBk);
    ellipse(0, 0, outSz, outSz);
  }
  void drawBullets() {
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
  void updateIndex() {
    int index = floor(angle / (2 * PI / division)) % division; // round -> floor
    if (currentIndex != index) {
      currentIndex = index;
      triggering = true;
    }
  }
  void clearBullet() {
    for (int i = bullets.size() - 1; i >= 0; i--) {
      Bullet b = bullets.get(i);
      if (!b.live) {
        bullets.remove(b);
      }
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
