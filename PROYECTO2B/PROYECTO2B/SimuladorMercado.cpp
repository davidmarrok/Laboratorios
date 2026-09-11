#include "SimuladorMercado.h"
#include "Portero.h"
#include "Defensa.h"
#include "Mediocampista.h"
#include "Delantero.h"

#include <iostream>
#include <iomanip>
#include <cstdlib>
#include <limits>

using namespace std;

SimuladorMercado::SimuladorMercado() {
	diaActual = 1;
	diasTotales = 0;
	presupuestoInicialUsuario = 0;
	hayOfertaUsuarioPendiente = false;
	hayOfertaSistemaPendiente = false;
	totalGastado = 0;
	totalRecibido = 0;
	ofertasAceptadas = 0;
	ofertasRechazadas = 0;
	contadorOfertas = 0;
}

// Unico lugar del programa donde se libera la memoria de los jugadores.
SimuladorMercado::~SimuladorMercado() {
	for (size_t i = 0; i < todosLosJugadores.size(); i++) {
		delete todosLosJugadores[i];
	}
	todosLosJugadores.clear();
}

int SimuladorMercado::leerEntero(const string& mensaje) const {
	int valor;
	while (true) {
		cout << mensaje;
		if (cin >> valor) {
			return valor;
		}
		else {
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
			cout << "Entrada invalida. Debe ingresar un numero entero.\n";
		}
	}
}

string SimuladorMercado::leerToken(const string& mensaje) const {
	string valor;
	cout << mensaje;
	cin >> valor;
	return valor;
}

int SimuladorMercado::contarPorPosicion(const Club& club, const string& posicion) const {
	int contador = 0;
	for (size_t i = 0; i < club.jugadores.size(); i++) {
		if (club.jugadores[i]->getPosicion() == posicion) {
			contador++;
		}
	}
	return contador;
}

Club* SimuladorMercado::buscarClubPorId(const string& idClub) {
	for (size_t i = 0; i < clubes.size(); i++) {
		if (clubes[i].id == idClub) {
			return &clubes[i];
		}
	}
	return nullptr;
}

Club* SimuladorMercado::buscarClubDeJugador(const string& idJugador) {
	Jugador* j = buscarJugadorPorId(idJugador);
	if (j == nullptr) return nullptr;
	return buscarClubPorId(j->getClubActual());
}

Jugador* SimuladorMercado::buscarJugadorPorId(const string& idJugador) {
	for (size_t i = 0; i < todosLosJugadores.size(); i++) {
		if (todosLosJugadores[i]->getId() == idJugador) {
			return todosLosJugadores[i];
		}
	}
	return nullptr;
}

string SimuladorMercado::generarIdOferta() {
	contadorOfertas++;
	return "OF" + to_string(contadorOfertas);
}

int SimuladorMercado::valorAleatorioPorPosicion(const string& posicion) const {
	int minimo, maximo;
	if (posicion == "Portero") { minimo = 20;  maximo = 70; }
	else if (posicion == "Defensa") { minimo = 25;  maximo = 90; }
	else if (posicion == "Mediocampista") { minimo = 30;  maximo = 110; }
	else /* Delantero */ { minimo = 35;  maximo = 140; }

	return minimo + (rand() % (maximo - minimo + 1));
}

void SimuladorMercado::crearJugador(const string& idClub, const string& id,
	const string& nombre, const string& posicion) {
	Jugador* nuevo = nullptr;

	if (posicion == "Portero") {
		nuevo = new Portero(id, nombre, 0, idClub);
	}
	else if (posicion == "Defensa") {
		nuevo = new Defensa(id, nombre, 0, idClub);
	}
	else if (posicion == "Mediocampista") {
		nuevo = new Mediocampista(id, nombre, 0, idClub);
	}
	else {
		nuevo = new Delantero(id, nombre, 0, idClub);
	}

	todosLosJugadores.push_back(nuevo);
	Club* club = buscarClubPorId(idClub);
	if (club != nullptr) {
		club->jugadores.push_back(nuevo);
	}
}

// Mueve el MISMO puntero de la plantilla de origen a la de destino.
void SimuladorMercado::moverJugadorEntreClubes(Jugador* jugador, const string& idOrigen,
	const string& idDestino) {
	Club* origen = buscarClubPorId(idOrigen);
	Club* destino = buscarClubPorId(idDestino);
	if (origen == nullptr || destino == nullptr) return;

	for (size_t i = 0; i < origen->jugadores.size(); i++) {
		if (origen->jugadores[i] == jugador) {
			origen->jugadores.erase(origen->jugadores.begin() + i);
			break;
		}
	}
	destino->jugadores.push_back(jugador);
	jugador->setClubActual(idDestino);
}

void SimuladorMercado::mostrarJugador(const Jugador* jugador) const {
	cout << "  - " << jugador->mostrarDescripcion() << "\n";
}

void SimuladorMercado::mostrarClubResumen(const Club& club) const {
	cout << club.id << " - " << club.nombre
		<< " | Presupuesto: " << club.presupuesto << "M EUR"
		<< " | Jugadores: " << club.jugadores.size() << "\n";
}

void SimuladorMercado::inicializarClubes() {
	clubes.clear();
	todosLosJugadores.clear();

	clubes.push_back({ "RM", "Real Madrid", 0, {} });
	clubes.push_back({ "FB", "FC Barcelona", 0, {} });
	clubes.push_back({ "MC", "Manchester City", 0, {} });
	clubes.push_back({ "LV", "Liverpool", 0, {} });
	clubes.push_back({ "BM", "Bayern Munich", 0, {} });
	clubes.push_back({ "PS", "Paris Saint-Germain", 0, {} });

	crearJugador("RM", "RM1", "Courtois", "Portero");
	crearJugador("RM", "RM2", "Militao", "Defensa");
	crearJugador("RM", "RM3", "Valverde", "Mediocampista");
	crearJugador("RM", "RM4", "Bellingham", "Mediocampista");
	crearJugador("RM", "RM5", "Mbappe", "Delantero");

	crearJugador("FB", "FB1", "J.Garcia", "Portero");
	crearJugador("FB", "FB2", "Cubarsi", "Defensa");
	crearJugador("FB", "FB3", "Pedri", "Mediocampista");
	crearJugador("FB", "FB4", "Yamal", "Delantero");
	crearJugador("FB", "FB5", "Raphinha", "Delantero");

	crearJugador("MC", "MC1", "Donnarumma", "Portero");
	crearJugador("MC", "MC2", "R.Dias", "Defensa");
	crearJugador("MC", "MC3", "Cherki", "Mediocampista");
	crearJugador("MC", "MC4", "Haaland", "Delantero");
	crearJugador("MC", "MC5", "Savinho", "Delantero");

	crearJugador("LV", "LV1", "Allison", "Portero");
	crearJugador("LV", "LV2", "VanDijk", "Defensa");
	crearJugador("LV", "LV3", "Szoboszlai", "Mediocampista");
	crearJugador("LV", "LV4", "MacAllister", "Mediocampista");
	crearJugador("LV", "LV5", "Isak", "Delantero");

	crearJugador("BM", "BM1", "Neuer", "Portero");
	crearJugador("BM", "BM2", "K.Minjae", "Defensa");
	crearJugador("BM", "BM3", "J.Tah", "Defensa");
	crearJugador("BM", "BM4", "Musiala", "Mediocampista");
	crearJugador("BM", "BM5", "Kane", "Delantero");

	crearJugador("PS", "PS1", "Chevalier", "Portero");
	crearJugador("PS", "PS2", "Pacho", "Defensa");
	crearJugador("PS", "PS3", "Vitinha", "Mediocampista");
	crearJugador("PS", "PS4", "J.Neves", "Mediocampista");
	crearJugador("PS", "PS5", "Dembele", "Delantero");
}

void SimuladorMercado::asignarPresupuestos() {
	for (size_t i = 0; i < clubes.size(); i++) {
		clubes[i].presupuesto = 100 + (rand() % 101);
	}
}

void SimuladorMercado::asignarValoresMercado() {
	for (size_t i = 0; i < todosLosJugadores.size(); i++) {
		Jugador* j = todosLosJugadores[i];
		j->setValorMercado(valorAleatorioPorPosicion(j->getPosicion()));
	}
}

void SimuladorMercado::configurarPartida() {
	inicializarClubes();

	cout << "\n===== CLUBES DISPONIBLES =====\n";
	for (size_t i = 0; i < clubes.size(); i++) {
		cout << clubes[i].id << " - " << clubes[i].nombre << "\n";
	}

	Club* elegido = nullptr;
	while (elegido == nullptr) {
		string idClub = leerToken("Ingrese el codigo del club que desea administrar: ");
		elegido = buscarClubPorId(idClub);
		if (elegido == nullptr) {
			cout << "Ese codigo de club no existe. Intente de nuevo.\n";
		}
	}
	clubUsuario = elegido->id;

	int dias;
	do {
		dias = leerEntero("Ingrese la cantidad de dias de simulacion (entre 5 y 15): ");
		if (dias < 5 || dias > 15) {
			cout << "Debe ingresar un valor entre 5 y 15.\n";
		}
	} while (dias < 5 || dias > 15);
	diasTotales = dias;

	asignarPresupuestos();
	asignarValoresMercado();

	Club* clubUsr = buscarClubPorId(clubUsuario);
	presupuestoInicialUsuario = clubUsr->presupuesto;
	plantillaInicialIds.clear();
	for (size_t i = 0; i < clubUsr->jugadores.size(); i++) {
		plantillaInicialIds.push_back(clubUsr->jugadores[i]->getId());
	}

	diaActual = 1;

	cout << "\n===== DATOS GENERADOS ANTES DEL DIA 1 =====\n";
	for (size_t i = 0; i < clubes.size(); i++) {
		mostrarClubResumen(clubes[i]);
		for (size_t j = 0; j < clubes[i].jugadores.size(); j++) {
			mostrarJugador(clubes[i].jugadores[j]);
		}
	}
	cout << "\nUsted administra: " << clubUsr->nombre
		<< " durante " << diasTotales << " dias.\n";
}

void SimuladorMercado::verMiClub() const {
	const Club* club = nullptr;
	for (size_t i = 0; i < clubes.size(); i++) {
		if (clubes[i].id == clubUsuario) { club = &clubes[i]; break; }
	}
	if (club == nullptr) return;

	cout << "\n===== MI CLUB: " << club->nombre << " =====\n";
	cout << "Presupuesto disponible: " << club->presupuesto << "M EUR\n";
	cout << "Plantilla (" << club->jugadores.size() << " jugadores):\n";
	for (size_t i = 0; i < club->jugadores.size(); i++) {
		mostrarJugador(club->jugadores[i]);
	}
}

void SimuladorMercado::explorarJugadores(const string& filtro) {
	cout << "\n===== JUGADORES DE OTROS CLUBES =====\n";
	bool encontrado = false;

	if (filtro == "TODOS") {
		for (size_t i = 0; i < todosLosJugadores.size(); i++) {
			Jugador* j = todosLosJugadores[i];
			if (j->getClubActual() != clubUsuario) {
				mostrarJugador(j);
				encontrado = true;
			}
		}
	}
	else if (filtro == "Portero" || filtro == "Defensa" ||
		filtro == "Mediocampista" || filtro == "Delantero") {
		for (size_t i = 0; i < todosLosJugadores.size(); i++) {
			Jugador* j = todosLosJugadores[i];
			if (j->getClubActual() != clubUsuario && j->getPosicion() == filtro) {
				mostrarJugador(j);
				encontrado = true;
			}
		}
	}
	else {
		Jugador* j = buscarJugadorPorId(filtro);
		if (j != nullptr && j->getClubActual() != clubUsuario) {
			mostrarJugador(j);
			encontrado = true;
		}
	}

	if (!encontrado) {
		cout << "No se encontraron resultados para esa busqueda.\n";
	}
}

void SimuladorMercado::realizarOferta() {
	if (hayOfertaUsuarioPendiente) {
		cout << "Ya tiene una oferta pendiente de resolverse. "
			<< "Avance el dia para conocer el resultado antes de ofertar de nuevo.\n";
		return;
	}

	string idJugador = leerToken("Ingrese el identificador del jugador por el que desea ofertar: ");
	Jugador* jugador = buscarJugadorPorId(idJugador);
	if (jugador == nullptr) {
		cout << "No existe ningun jugador con ese identificador.\n";
		return;
	}
	if (jugador->getClubActual() == clubUsuario) {
		cout << "No puede ofertar por un jugador de su propio club.\n";
		return;
	}

	int monto;
	do {
		monto = leerEntero("Ingrese el monto a ofrecer (millones de euros, entero positivo): ");
		if (monto <= 0) cout << "El monto debe ser un entero positivo.\n";
	} while (monto <= 0);

	Oferta nueva;
	nueva.id = generarIdOferta();
	nueva.jugador = jugador;
	nueva.comprador = clubUsuario;
	nueva.vendedor = jugador->getClubActual();
	nueva.monto = monto;
	nueva.estado = "pendiente";
	nueva.tipo = "usuario";

	ofertaUsuarioPendiente = nueva;
	hayOfertaUsuarioPendiente = true;

	cout << "Oferta registrada por " << jugador->getNombre()
		<< " (" << monto << "M EUR). Se resolvera al avanzar el dia.\n";
}

void SimuladorMercado::revisarOfertasRecibidas() {
	if (!hayOfertaSistemaPendiente) {
		cout << "No hay ofertas pendientes por revisar hoy.\n";
		return;
	}

	Jugador* jugador = ofertaSistemaPendiente.jugador;
	Club* clubComprador = buscarClubPorId(ofertaSistemaPendiente.comprador);

	cout << "\n===== OFERTA RECIBIDA =====\n";
	cout << clubComprador->nombre << " ofrece " << ofertaSistemaPendiente.monto
		<< "M EUR por " << jugador->getNombre()
		<< " (valor actual: " << jugador->getValorMercado() << "M EUR).\n";

	string respuesta;
	do {
		respuesta = leerToken("Desea aceptar esta oferta? (si/no): ");
	} while (respuesta != "si" && respuesta != "no");

	if (respuesta == "no") {
		ofertaSistemaPendiente.estado = "rechazada";
		ofertasRechazadas++;
		cout << "Oferta rechazada.\n";
	}
	else {
		Club* clubUsr = buscarClubPorId(clubUsuario);
		int cantidadEnPosicion = contarPorPosicion(*clubUsr, jugador->getPosicion());

		if (cantidadEnPosicion <= 1) {
			cout << "No puede vender a " << jugador->getNombre()
				<< ": su club se quedaria sin jugadores en la posicion "
				<< jugador->getPosicion() << ". Oferta rechazada automaticamente.\n";
			ofertaSistemaPendiente.estado = "rechazada";
			ofertasRechazadas++;
		}
		else {
			int monto = ofertaSistemaPendiente.monto;
			moverJugadorEntreClubes(jugador, clubUsuario, clubComprador->id);
			clubComprador->presupuesto -= monto;
			clubUsr->presupuesto += monto;

			Transferencia t;
			t.dia = diaActual;
			t.jugador = jugador->getNombre();
			t.origen = clubUsuario;
			t.destino = clubComprador->id;
			t.montoPagado = monto;
			historial.push_back(t);

			totalRecibido += monto;
			ofertasAceptadas++;
			ofertaSistemaPendiente.estado = "aceptada";

			cout << "Oferta aceptada. " << jugador->getNombre()
				<< " se transfirio a " << clubComprador->nombre
				<< " por " << monto << "M EUR.\n";
		}
	}

	ofertas.push_back(ofertaSistemaPendiente);
	hayOfertaSistemaPendiente = false;
}

void SimuladorMercado::avanzarDia() {
	cout << "\n===== AVANZANDO AL DIA " << (diaActual + 1) << " =====\n";

	if (hayOfertaUsuarioPendiente) {
		Oferta& of = ofertaUsuarioPendiente;
		Jugador* jugador = of.jugador;
		Club* comprador = buscarClubPorId(of.comprador);
		Club* vendedor = buscarClubPorId(of.vendedor);
		int valorActual = jugador->getValorMercado();
		int minimoAceptable = (valorActual * 110) / 100;

		cout << "Resolviendo su oferta por " << jugador->getNombre()
			<< " (" << of.monto << "M EUR)... ";

		if (of.monto < minimoAceptable) {
			cout << "RECHAZADA: el monto es menor al 110% del valor actual ("
				<< minimoAceptable << "M EUR requeridos).\n";
			of.estado = "rechazada";
			ofertasRechazadas++;
		}
		else if (comprador->presupuesto < of.monto) {
			cout << "RECHAZADA: su club no tiene presupuesto suficiente.\n";
			of.estado = "rechazada";
			ofertasRechazadas++;
		}
		else if (contarPorPosicion(*vendedor, jugador->getPosicion()) <= 1) {
			cout << "RECHAZADA: el club vendedor se quedaria sin jugadores en la posicion "
				<< jugador->getPosicion() << ".\n";
			of.estado = "rechazada";
			ofertasRechazadas++;
		}
		else {
			comprador->presupuesto -= of.monto;
			vendedor->presupuesto += of.monto;
			moverJugadorEntreClubes(jugador, of.vendedor, of.comprador);

			Transferencia t;
			t.dia = diaActual;
			t.jugador = jugador->getNombre();
			t.origen = of.vendedor;
			t.destino = of.comprador;
			t.montoPagado = of.monto;
			historial.push_back(t);

			totalGastado += of.monto;
			of.estado = "aceptada";
			ofertasAceptadas++;
			cout << "ACEPTADA: " << jugador->getNombre() << " se une a su club.\n";
		}

		ofertas.push_back(of);
		hayOfertaUsuarioPendiente = false;
	}
	else {
		cout << "No tenia ninguna oferta propia pendiente.\n";
	}

	if (!hayOfertaSistemaPendiente) {
		Club* clubUsr = buscarClubPorId(clubUsuario);
		if (!clubUsr->jugadores.empty() && (rand() % 100) < 70) {
			int indice = rand() % clubUsr->jugadores.size();
			Jugador* objetivo = clubUsr->jugadores[indice];

			Club* compradorRival = nullptr;
			do {
				int idxClub = rand() % clubes.size();
				if (clubes[idxClub].id != clubUsuario) compradorRival = &clubes[idxClub];
			} while (compradorRival == nullptr);

			int valor = objetivo->getValorMercado();
			int porcentaje = 90 + (rand() % 41);
			int monto = (valor * porcentaje) / 100;

			Oferta nueva;
			nueva.id = generarIdOferta();
			nueva.jugador = objetivo;
			nueva.comprador = compradorRival->id;
			nueva.vendedor = clubUsuario;
			nueva.monto = monto;
			nueva.estado = "pendiente";
			nueva.tipo = "sistema";

			ofertaSistemaPendiente = nueva;
			hayOfertaSistemaPendiente = true;

			cout << compradorRival->nombre << " ha generado una nueva oferta por su jugador "
				<< objetivo->getNombre() << ". Revisela con la opcion correspondiente.\n";
		}
	}

	for (size_t i = 0; i < todosLosJugadores.size(); i++) {
		Jugador* j = todosLosJugadores[i];
		int valor = j->getValorMercado();
		int variacion = -5 + (rand() % 11);
		int nuevoValor = valor + (valor * variacion) / 100;
		if (nuevoValor < 5) nuevoValor = 5;
		j->setValorMercado(nuevoValor);
	}

	diaActual++;
	cout << "Los valores de mercado se actualizaron. Ahora es el dia " << diaActual << ".\n";
}

void SimuladorMercado::verHistorial() const {
	cout << "\n===== HISTORIAL DE TRANSFERENCIAS =====\n";
	if (historial.empty()) {
		cout << "Aun no se ha completado ninguna transferencia.\n";
		return;
	}
	for (size_t i = 0; i < historial.size(); i++) {
		const Transferencia& t = historial[i];
		cout << "Dia " << t.dia << " | " << t.jugador
			<< " | " << t.origen << " -> " << t.destino
			<< " | " << t.montoPagado << "M EUR\n";
	}
}

void SimuladorMercado::generarReporteFinal() const {
	const Club* clubUsr = nullptr;
	for (size_t i = 0; i < clubes.size(); i++) {
		if (clubes[i].id == clubUsuario) { clubUsr = &clubes[i]; break; }
	}

	cout << "\n=========================================\n";
	cout << "            REPORTE FINAL\n";
	cout << "=========================================\n";

	cout << "\nPlantilla inicial (" << plantillaInicialIds.size() << " jugadores):\n";
	for (size_t i = 0; i < plantillaInicialIds.size(); i++) {
		cout << "  - " << plantillaInicialIds[i] << "\n";
	}

	cout << "\nPlantilla final (" << clubUsr->jugadores.size() << " jugadores):\n";
	for (size_t i = 0; i < clubUsr->jugadores.size(); i++) {
		mostrarJugador(clubUsr->jugadores[i]);
	}

	cout << "\nPresupuesto inicial: " << presupuestoInicialUsuario << "M EUR\n";
	cout << "Presupuesto final disponible: " << clubUsr->presupuesto << "M EUR\n";
	cout << "Total gastado en compras: " << totalGastado << "M EUR\n";
	cout << "Total recibido por ventas: " << totalRecibido << "M EUR\n";

	cout << "\nJugadores comprados por su club:\n";
	bool huboCompras = false;
	for (size_t i = 0; i < historial.size(); i++) {
		if (historial[i].destino == clubUsuario) {
			cout << "  - " << historial[i].jugador << " (Dia " << historial[i].dia
				<< ", " << historial[i].montoPagado << "M EUR)\n";
			huboCompras = true;
		}
	}
	if (!huboCompras) cout << "  (ninguno)\n";

	cout << "\nJugadores vendidos por su club:\n";
	bool huboVentas = false;
	for (size_t i = 0; i < historial.size(); i++) {
		if (historial[i].origen == clubUsuario) {
			cout << "  - " << historial[i].jugador << " (Dia " << historial[i].dia
				<< ", " << historial[i].montoPagado << "M EUR)\n";
			huboVentas = true;
		}
	}
	if (!huboVentas) cout << "  (ninguno)\n";

	cout << "\nOfertas aceptadas: " << ofertasAceptadas << "\n";
	cout << "Ofertas rechazadas: " << ofertasRechazadas << "\n";

	verHistorial();
	cout << "\n=========================================\n";
	cout << "  Gracias por jugar Mercato 2026.\n";
	cout << "=========================================\n";
}

bool SimuladorMercado::simulacionTerminada() const {
	return diaActual > diasTotales;
}

void SimuladorMercado::ejecutarMenu() {
	configurarPartida();

	while (!simulacionTerminada()) {
		cout << "\n----------------------------------------\n";
		cout << "Dia " << diaActual << " de " << diasTotales << "\n";
		cout << "1. Ver mi club\n";
		cout << "2. Explorar jugadores\n";
		cout << "3. Realizar una oferta\n";
		cout << "4. Revisar ofertas recibidas\n";
		cout << "5. Ver historial\n";
		cout << "6. Avanzar de dia\n";
		cout << "----------------------------------------\n";

		int opcion = leerEntero("Seleccione una opcion (1-6): ");

		switch (opcion) {
		case 1:
			verMiClub();
			break;
		case 2: {
			cout << "Buscar por: (1) Todos  (2) Posicion  (3) Identificador\n";
			int modo = leerEntero("Seleccione una opcion (1-3): ");
			if (modo == 1) {
				explorarJugadores("TODOS");
			}
			else if (modo == 2) {
				string pos = leerToken("Posicion (Portero/Defensa/Mediocampista/Delantero): ");
				explorarJugadores(pos);
			}
			else if (modo == 3) {
				string id = leerToken("Identificador del jugador: ");
				explorarJugadores(id);
			}
			else {
				cout << "Opcion invalida.\n";
			}
			break;
		}
		case 3:
			realizarOferta();
			break;
		case 4:
			revisarOfertasRecibidas();
			break;
		case 5:
			verHistorial();
			break;
		case 6:
			avanzarDia();
			break;
		default:
			cout << "Opcion invalida. Debe ingresar un numero entre 1 y 6.\n";
		}
	}

	generarReporteFinal();
}