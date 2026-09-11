#include "Mediocampista.h"

string Mediocampista::mostrarDescripcion() const {
	return "Mediocampista -->" + getNombre() + " Id: " + getId() + " Club: " + getClubActual() +" Valor: " + to_string(getValorMercado());
}

string Mediocampista::getPosicion() const {
	return "Mediocampista";
}