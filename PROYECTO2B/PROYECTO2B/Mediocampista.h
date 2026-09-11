#pragma once
#include "Jugador.h"

class Mediocampista : public Jugador
{
public:
	Mediocampista(string id, string nombre, int valorMercado, string clubActual)
		: Jugador(id, nombre, valorMercado, clubActual) {
	}

	string mostrarDescripcion() const override;
	string getPosicion() const override;
};