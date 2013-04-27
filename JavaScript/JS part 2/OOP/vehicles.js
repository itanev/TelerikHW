function Vehicle() {
	var speed = 0;
	var propulsionUnits = [];
	
	this.addPropulsionUnit = function (unit) {
		propulsionUnits.push(unit);
	}
	
	this.calcSpeed = function() {
		var i;
		speed = 0;
		
		for( i = 0; i < propulsionUnits.length; i++ ) {
			speed += propulsionUnits[i].getAcceleration();
		}
	}
	
	this.getSpeed = function () {
		return speed;
	}
}

function PropulsionUnit() {
	var acceleration;
	
	//public functions
	this.getAcceleration = function() {
		return this.acceleration;
	}
	
	this.setAcceleration = function(value) {
		this.acceleration = value;
	}
}

function Wheel() {
	PropulsionUnit.call(this);
	
	var radius = 10;
	
	this.setAcceleration(2 * Math.PI * radius);
}
//inherit PropulsionUnit
Wheel.prototype = Object.create(PropulsionUnit.prototype);

function PropellingNozzle(afterburnerOn) {
	PropulsionUnit.call(this);
	
	var power = 10;
	
	if(afterburnerOn) {
		this.setAcceleration(2 * power);
	}
	else {
		this.setAcceleration(power);
	}
}

// inherit PropulsionUnit
PropellingNozzle.prototype = Object.create(PropulsionUnit.prototype);

// true means clockwise
function Propeller(numberFins, spinDirection) {
	PropulsionUnit.call(this);
	
	if(spinDirection) {
		this.setAcceleration(numberFins);
	}
	else {
		this.setAcceleration(-1 * numberFins);
	}
}

//inherit PropulsionUnit
Propeller.prototype = Object.create(PropulsionUnit.prototype);

function LandVehicle(numWheels) {
	Vehicle.call(this);
	
	var wheel = new Wheel();
	var i;
	
	for(i = 0; i < numWheels; i++) {
		this.addPropulsionUnit(wheel);
	}
	
	this.calcSpeed();
}

//inherit Vehicle
LandVehicle.prototype = Object.create(Vehicle.prototype);

function AirVehicle() {
	Vehicle.call(this);
	
	this.addNozzle = function (afterburnerOn) {
		this.addPropulsionUnit(new PropellingNozzle(afterburnerOn)); 
		this.calcSpeed();
	}
}

//inherit Vehicle
AirVehicle.prototype = Object.create(Vehicle.prototype);

function WaterVehicles() {
	Vehicle.call(this);
	
	this.addPropeller = function (numFins, spinDirection) {
		this.addPropulsionUnit(new Propeller(numFins, spinDirection)); 
		this.calcSpeed();
	}
}

//inherit Vehicle
WaterVehicles.prototype = Object.create(Vehicle.prototype);

function AmphibiousVehicle(mode) {
	Vehicle.call(this);
	
	if(mode == 'land') {
		LandVehicle.call(this, 4);
	}
	else {
		WaterVehicles.call(this);
	}
}

//inherit Vehicle
AmphibiousVehicle.prototype = Object.create(Vehicle.prototype);
