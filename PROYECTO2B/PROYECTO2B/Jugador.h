#pragma once
#include <string>
using namespace std;
class Jugador
{
private:
	string id, nombre, clubActual;
	int valorMercado;
public:
	Jugador(string id, string nombre, int valorMercado, string clubActual) {
		this->id = id;
		this->nombre = nombre;
		this->valorMercado = valorMercado;
		this->clubActual = clubActual;
	}

	virtual ~Jugador() {};
	virtual string mostrarDescripcion() const = 0;
	virtual string getPosicion() const = 0;

	string getId() const {
		return id;
	}

	string getNombre() const {
		return nombre;
	}

	int getValorMercado() const {
		return valorMercado;
	}

	string getClubActual() const {
		return clubActual;
	}

	void setValorMercado(int valorMercado) {
		this->valorMercado = valorMercado;
	}

	void setClubActual(string clubActual) {
		this->clubActual = clubActual;
	}

};