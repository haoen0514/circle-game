class Circle {
  float sz;
  float angle = 0;

  Circle(float _sz) {
    sz = _sz;
  }

  void update() {
    angle += 0.01;
  }

  void render() {
    pushMatrix();

    translate(width / 2, height / 2);
    stroke(colOfLine);
    strokeWeight(2);
    fill(colOfCircle);
    ellipse(0, 0, sz, sz);
    drawLine();
    popMatrix();
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
}
