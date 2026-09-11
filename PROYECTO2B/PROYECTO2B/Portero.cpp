#include "Portero.h"

string Portero::mostrarDescripcion() const {
	return "Portero --> " + getNombre() + "Id: " + getId() + " Club: " + getClubActual() +" Valor : " + to_string(getValorMercado());
}

string Portero::getPosicion() const {
	return "Portero";
}