// colors
color colOfBk = color (30, 30, 30);
color colOfCircle = color (200, 200, 200);
color colOfOutCircle = color (54, 215, 183);
color colOfLine = color (224, 130, 131);
color colOfPoint = color (75, 119, 190);

Circle circle;


void setup() {
  size(800, 800);
  background(colOfBk);
  circle = new Circle(width / 2);
}


void draw() {
  background(colOfBk);
  circle.update();
  circle.render();
  circle.mouseSensed();
}

void mousePressed() {
  circle.mousePressed();
}
