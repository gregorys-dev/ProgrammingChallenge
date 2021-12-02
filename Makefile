#Makefile

build:
	docker build -t programming-challenge .
 
run:
	docker run -d -p 8080:80 programming-challenge
