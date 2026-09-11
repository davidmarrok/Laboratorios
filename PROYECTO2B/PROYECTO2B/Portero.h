#pragma once
#include "Jugador.h"

class Portero : public Jugador
{
public:
	Portero(string id, string nombre, int valorMercado, string clubActual)
		: Jugador(id, nombre, valorMercado, clubActual) {
	}

	string mostrarDescripcion() const override;
	string getPosicion() const override;
};