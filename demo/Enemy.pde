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

  void update() {
    // angle += (finalAngle - angle) * accel;

    position -= 0.2;
    if (position < circle.sz) {
      live = false;
      gameOver = true;
    }
  }

  void render() {
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
