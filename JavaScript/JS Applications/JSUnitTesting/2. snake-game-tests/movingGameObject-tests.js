module("Snake.init");

test("When moving object is initialized, should set the correct values", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var fcolor = '#fff000';
  var scolor = '#000fff';
  var size = 5;
  var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

  equal(position, snake.position, "Position is set");
  equal(speed, snake.speed, "Speed is set");
  equal(direction, snake.direction, "Direction is set");
  equal(size, snake.size, "Size is set");
  equal(fcolor, snake.fcolor, "Fcolor is set");
  equal(scolor, snake.scolor, "Scolor is set");
});

test("When moving object moves, should set the correct coords", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var fcolor = '#fff000';
  var scolor = '#000fff';
  var size = 5;
  var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
  snake.move();

  equal(position, snake.position, "Position is correct");
});

test("When moving object moves, should set the correct coords", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var fcolor = '#fff000';
  var scolor = '#000fff';
  var size = 5;
  var snake = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
  snake.changeDirection(1);
  var newDirection = 1;

  equal(newDirection, snake.direction, "Direction is correct");
});