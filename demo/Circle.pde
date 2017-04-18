final float RATIO = 1.9;
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

  void update() {
    // rotate
    println("angle:" + angle);
    angle = (millis() / 1000.0) - lastAngle;
    if (angle > 2 * PI) {
      lastAngle = (millis() / 1000.0);
      create();
    }

    // createEnemy
    updateIndex();
    clearBullet();
    clearEnemies();
    checkCollision();
  }

  void create() {
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

  void render() {
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

    fill(colOfLine);
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
        bullets.add(new Bullet(this, b.angle));
      }
    }
    triggering = false;
  }
  void drawEnemies() {
    for (int i = 0, n = enemies.size(); i < n; i++) {
      Enemy e = enemies.get(i);
      e.update();
      e.render();
    }
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

  // enemies control
  void createEnemy() {
    enemies.add(new Enemy(this, floor(random(division))));
  }
  void createEnemy(int i) {
    enemies.add(new Enemy(this, i % division));
  }
  void clearEnemies() {
    for (int i = enemies.size() - 1; i >= 0; i--) {
      Enemy e = enemies.get(i);
      if (!e.live) {
        enemies.remove(e);
      }
    }
  }

  void checkCollision() {
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
