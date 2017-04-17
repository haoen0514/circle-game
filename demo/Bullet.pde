class Bullet {

  // states
  boolean flying = false;

  Circle circle;
  float angle;
  float finalAngle;
  float accel = 0.1;

  int division;
  float position;

  Bullet(Circle _c, float _a) {
    circle = _c;
    angle = _a;
    division = circle.division;
    index =  round(_a / (PI / circle.division));
    finalAngle = round(_a / (PI / circle.division)) * (PI / circle.division);
    position = circle.sz;
  }

  void update() {
    angle += (finalAngle - angle) * accel;

    if (flying) {
      position += 2;
    }

  }

  void render() {
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

  void trigger() {
    flying = true;
  }
}
