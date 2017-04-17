// colors
color colOfBk = color (44, 62, 80);
color colOfCircle = color (51, 110, 123);
// color colOfOutCircle = color (54, 215, 183);
color colOfOutCircle = color (51, 110, 123);
color colOfLine = color (224, 130, 131);
color colOfPoint = color (75, 119, 190);

Circle circle;


void setup() {
  size(800, 800);
  circle = new Circle(width / 2);
}


void draw() {
  circle.update();
  circle.render();
  circle.mouseSensed();
}

void mousePressed() {
  circle.mousePressed();
}
