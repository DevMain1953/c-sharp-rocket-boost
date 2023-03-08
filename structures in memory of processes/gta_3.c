struct car {
	xCoordinate = car + 0x34;
	yCoordinate = car + 0x38;
	zCoordinate = car + 0x3C;

	sinusOfYawAngle = car + 0x14;
   	cosineOfYawAngle = car + 0x18;

	sinusOfRollAngle = car + 0xC;
   -sinusOfPitchAngle = car + 0x1C;

	xVector = car + 0x78;
	yVector = car + 0x7C;
	zVector = car + 0x80;
	carID = car + 0x5C;
	primaryColor = car + 0x19C; //datatype - byte
	secondaryColor = car + 0x19D; //datatype - byte
	health = car + 0x200;
};

struct player {
	xCoordinate = player + 0x34;
	yCoordinate = player + 0x38;
	zCoordinate = player + 0x3C;
	
	xVector = player + 0x78;
	yVector = player + 0x7C;
	zVector = player + 0x80;

	p_car = player + 0x310;
	car = getAddressFrom(p_car);

	p_touchedObject = player + 0x1 + 0xF0;
	health = player + 0x2C0;
	armor = player + 0x2C4;
};

structure_of_player = 6267624;
structure_of_car = 6294020;
structure_of_helicopter = 6297984;
structure_of_plane = 6298532;
