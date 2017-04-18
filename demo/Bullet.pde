class Bullet {

  // states
  boolean flying = false;
  boolean live = true;

  Circle circle;
  float angle;
  float finalAngle;
  float accel = 0.1;

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

  void update() {
    angle += (finalAngle - angle) * accel;

    if (flying) {
      position += 2;
      if (position > circle.outSz) {
        live = false;
        gameOver = true;
      }
    }

  }

  void render() {
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

  void trigger() {
    flying = true;
  }
}
