test("When food is initialized, should set the correct values", function() {
  var position = {
    x: 150,
    y: 150
  };  
  var size = 5;
  var food = new snakeGame.Food(position, size);

  equal(position, food.position, "Position is set");
  equal(size, food.size, "Size is set");
});

test("When food change it's position, should set the correct coords", function() {
  var position = {
    x: 150,
    y: 150
  };
  var size = 5;
  var food = new snakeGame.Food(position, size);
  var newPos = {
    x: 179,
    y: 10
  };
  food.changePosition(newPos);
  ok(newPos.x == food.position.x);
  ok(newPos.y == food.position.y);
});