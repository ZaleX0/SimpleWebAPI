\connect simplewebapi_db

CREATE TABLE addresses (
	id SERIAL PRIMARY KEY,
	city TEXT NOT NULL,
	street TEXT NOT NULL,
	postal_code TEXT NOT NULL
);

CREATE TABLE persons (
	id SERIAL PRIMARY KEY,
	name TEXT NOT NULL,
	lastname TEXT NOT NULL,
	address_id INTEGER
);

