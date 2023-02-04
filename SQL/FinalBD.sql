--Procedimientos
CREATE OR REPLACE PROCEDURE crearJugador (
    p_cedula IN NUMBER,
    p_nombre IN VARCHAR2,
    p_sueldo IN NUMBER,
    p_posicion IN VARCHAR2,
    p_comision IN NUMBER,
    p_estado IN VARCHAR2,
    p_fechaingequipo IN DATE
)
AS
BEGIN
    INSERT INTO jugador VALUES (p_cedula, null, p_nombre, 0, p_sueldo, p_posicion,
    p_comision, p_fechaingequipo, p_estado);
END;

create or replace PROCEDURE crearEquipo (equ_id IN NUMBER, equ_nombre IN VARCHAR2, equ_representa IN VARCHAR2)
AS
BEGIN
  INSERT INTO equipo VALUES (equ_id, equ_nombre, equ_representa, 0);
END;

CREATE OR REPLACE PROCEDURE crearUbicacion(p_ID IN NUMBER, p_direccion IN VARCHAR2, p_ciudad IN VARCHAR2)
AS
BEGIN
   INSERT INTO ubicacion
   VALUES (p_ID, p_direccion, p_ciudad);
END;

CREATE OR REPLACE PROCEDURE pro_crearCancha (prm_canid cancha.can_id%TYPE, prm_ubiid cancha.ubi_id%TYPE, prm_canname cancha.can_nombre%TYPE)
IS
BEGIN
    INSERT INTO cancha VALUES (prm_canid, prm_ubiid, prm_canname);
END;

CREATE OR REPLACE PROCEDURE pro_crearTorneo (prm_torid torneo.tor_id%TYPE, prm_torname torneo.tor_nombre%TYPE)
IS
BEGIN
    INSERT INTO torneo VALUES (prm_torid, prm_torname);
END;

CREATE OR REPLACE PROCEDURE pro_crearPartido (prm_parid partido.par_id%TYPE, prm_canid cancha.can_id%TYPE, prm_torid torneo.tor_id%TYPE, prm_pardate partido.par_fecha%TYPE, prm_goles1 partido.par_golesequ1%TYPE, prm_goles2 partido.par_golesequ2%TYPE, prm_tipo partido.par_tipo%TYPE, prm_numentradas partido.par_numentradavends%TYPE, prm_precioentradas partido.par_precioentradas%TYPE, prm_parestado partido.par_estado%TYPE)
IS
BEGIN
    INSERT INTO partido VALUES (prm_parid, prm_canid, prm_torid, prm_pardate, prm_goles1, prm_goles2, prm_tipo, prm_numentradas, prm_precioentradas, prm_parestado);
END;

--Funciones
CREATE OR REPLACE FUNCTION fun_diferenciaGoles(prm_idteam NUMBER) RETURN NUMBER
IS
    var_GolesTeam NUMBER := 0;
    var_GolesJug NUMBER := 0;
    var_GolDiferencia NUMBER := 0;
BEGIN
     SELECT equ_goles INTO var_GolesTeam FROM equipo WHERE equ_id = prm_idteam;
     SELECT SUM(jug_numgoles) INTO var_GolesJug FROM jugador WHERE equ_id = prm_idteam;
     var_GolDiferencia := (var_GolesTeam - var_GolesJug);
     IF var_goldiferencia < 0 THEN
        DBMS_OUTPUT.PUT_LINE('Hay mas goles marcados por jugadores registrados que en el equipo en si');
        ELSE IF var_goldiferencia = 0 THEN
            DBMS_OUTPUT.PUT_LINE('Los goles registrados por jugadores son iguales a los del equipo');
            ELSE
                DBMS_OUTPUT.PUT_LINE('Los goles registrados por el equipo son mayores al de los jugadores actuales registrados en el mismo');
        END IF;
    END IF;
     RETURN var_GolDiferencia;
END;


CREATE OR REPLACE FUNCTION fun_jugContarTarj (prm_par partido.par_id%TYPE) RETURN jugador.jug_nombre%TYPE
IS
    var_jug jugador.jug_nombre%TYPE := null;
    var_numtar NUMBER;
    var_jugmax NUMBER;
BEGIN
    SELECT COUNT(tar_id) AS numtarj, jug_cedula INTO var_numtar, var_jugmax FROM tarjetajugador WHERE tar_id = 1 AND par_id = prm_par GROUP BY jug_cedula ORDER BY numtarj DESC FETCH FIRST 1 ROW ONLY;
    SELECT jug_nombre INTO var_jug FROM jugador WHERE jug_cedula = var_jugmax;
    RETURN var_jug;
END;

CREATE OR REPLACE FUNCTION fun_obtenerGanador (prm_partido NUMBER) RETURN NUMBER
IS
    var_golteam1 NUMBER;
    var_golteam2 NUMBER;
    var_winner NUMBER := 0;
BEGIN
    SELECT par_golesequ1, par_golesequ2 INTO var_golteam1, var_golteam2 FROM partido WHERE par_id = prm_partido;
    IF var_golteam1 > var_golteam2 THEN
        SELECT equ_id INTO var_winner FROM equipopartido WHERE jue_como = 1 AND par_id = prm_partido;
    ELSE
        SELECT equ_id INTO var_winner FROM equipopartido WHERE jue_como = 2 AND par_id = prm_partido;
    END IF;
    RETURN var_winner;
END;

--TRIGGERS
CREATE OR REPLACE TRIGGER tri_noRepetirEquipo BEFORE INSERT OR UPDATE ON EQUIPOPARTIDO FOR EACH ROW
DECLARE
    var_teamjuega NUMBER := 0;
BEGIN
    SELECT count(equ_id) INTO var_teamjuega FROM EQUIPOPARTIDO WHERE equ_id = :NEW.equ_id AND par_id = :NEW.par_id;
    IF var_teamjuega != 0 THEN
        raise_application_error(-20002, 'El equipo ' || :NEW.equ_id || ' ya juega en este partido ' || var_teamjuega || ' Veces');
    END IF;
END;

CREATE OR REPLACE TRIGGER tri_sumGolesJugATeam AFTER UPDATE OF jug_numgoles ON jugador FOR EACH ROW
DECLARE
    var_golesActuales NUMBER;
BEGIN
    IF :NEW.jug_posicionjue != 'Arquero' THEN
        SELECT equ_goles INTO var_golesActuales FROM equipo WHERE equ_id = :NEW.equ_id;
        UPDATE equipo SET equ_goles = (:NEW.jug_numgoles + var_golesActuales) WHERE equ_id = :NEW.equ_id;
    END IF;
END;

CREATE OR REPLACE TRIGGER tri_sumgolespartido FOR UPDATE OF par_estado ON partido COMPOUND TRIGGER
    var_idequ1 NUMBER;
    var_golequ1 NUMBER;
    var_pargolequ1 NUMBER;
    var_idequ2 NUMBER;
    var_golequ2 NUMBER;
    var_pargolequ2 NUMBER;
    
    var_par NUMBER;
    var_estado partido.par_estado%TYPE;
AFTER EACH ROW IS
    BEGIN
        var_par := :NEW.par_id;
        var_estado := :NEW.par_estado;
 END AFTER EACH ROW;

AFTER STATEMENT IS
    BEGIN
        IF var_estado = 'Finalizado' THEN
            SELECT equipo.equ_id, equ_goles, par_golesequ1 INTO var_idequ1, var_golequ1, var_pargolequ1 FROM partido 
                INNER JOIN equipopartido ON partido.par_id = equipopartido.par_id 
                INNER JOIN equipo ON equipo.equ_id = equipopartido.equ_id WHERE jue_como = 1 AND partido.par_id = var_par;
            SELECT equipo.equ_id, equ_goles ,par_golesequ2 INTO var_idequ2, var_golequ2, var_pargolequ2 FROM partido 
                INNER JOIN equipopartido ON partido.par_id = equipopartido.par_id 
                INNER JOIN equipo ON equipo.equ_id = equipopartido.equ_id WHERE jue_como = 2 AND partido.par_id = var_par;
        END IF;
        UPDATE equipo SET equ_goles = (var_golequ1 + var_pargolequ1) WHERE equ_id = var_idequ1;
        UPDATE equipo SET equ_goles = (var_golequ2 + var_pargolequ2) WHERE equ_id = var_idequ2;
END AFTER STATEMENT;
END;

CREATE OR REPLACE TRIGGER tri_noCoincidirPartidos BEFORE INSERT OR UPDATE OF par_fecha ON partido FOR EACH ROW
DECLARE
    var_numpartidos NUMBER := 0;
    var_lastdate DATE;
BEGIN
    SELECT COUNT(par_id) INTO var_numpartidos FROM partido WHERE par_fecha BETWEEN :NEW.par_fecha - 1 AND :NEW.par_fecha;
    IF var_numpartidos != 0 THEN 
        DBMS_OUTPUT.PUT_LINE ('Coincide: ' || var_numpartidos || ' las fechas entre ' || TO_CHAR(:NEW.par_fecha - 1) || ' y ' || TO_CHAR(:NEW.par_fecha));
        pck_globalvars.var_mesaumento := pck_globalvars.var_mesaumento + 30;
    END IF;
END;

/*Necesario inicializar "var_agregarComision" con el valor de aumento*/
CREATE OR REPLACE TRIGGER tri_aumentarComisionJug AFTER UPDATE OF jug_numgoles ON jugador FOR EACH ROW
DECLARE
    var_agregarComision NUMBER := 1;
    var_limiteComision NUMBER := 100;
    var_comisionActual NUMBER := 0;
    var_golesActuales NUMBER := 0;
    var_nuevaComision NUMBER := 0;
BEGIN
    SELECT jug_comision, jug_numgoles INTO var_comisionActual, var_golesActuales FROM jugador WHERE jug_cedula = :NEW.jug_cedula;
    IF var_comisionActual < var_limiteComision THEN
        var_nuevaComision := var_comisionActual + (var_agregarComision * (:NEW.jug_numgoles - var_golesActuales));
        IF var_nuevaComision < var_limiteComision THEN
            UPDATE equipo SET equ_goles = (:NEW.jug_numgoles + var_golesActuales) WHERE equ_id = :NEW.equ_id;
            UPDATE jugador SET jug_comision  = var_nuevaComision WHERE jug_cedula = :NEW.jug_cedula;
        ELSE
            UPDATE jugador SET jug_comision  = var_limiteComision WHERE jug_cedula = :NEW.jug_cedula;
        END IF;
    END IF;
END;

CREATE OR REPLACE TRIGGER tri_limitarTeamsParticipantes BEFORE INSERT OR UPDATE ON EQUIPOPARTIDO FOR EACH ROW
DECLARE
    var_numParticipantes NUMBER := 0;
BEGIN
    SELECT count(equ_id) INTO var_numParticipantes FROM EQUIPOPARTIDO WHERE par_id = :NEW.par_id;
    IF var_numParticipantes = 2 THEN
        raise_application_error(-20003, 'Ya hay dos equipos registrados para este partido');
        ELSE IF var_numParticipantes > 2 THEN
            raise_application_error(-20004, 'ERROR!: Hay mas de dos equipos registrados para este partido');
        END IF;
    END IF;
END;

CREATE OR REPLACE TRIGGER tri_jugActivosNecesarios BEFORE INSERT OR UPDATE ON EQUIPOPARTIDO FOR EACH ROW
DECLARE
    var_jugactivos NUMBER := 0;
BEGIN
    SELECT count(jug_cedula) INTO var_jugactivos FROM jugador WHERE equ_id = :NEW.equ_id AND jug_estado = 'Habilitado';
    IF var_jugactivos < 11 THEN
        raise_application_error(-20005, 'No hay jugadores habiles suficientes en el equipo para participar, jugadores activos: ' || var_jugactivos);
    END IF;
END;

--Trigger para automatizacion, evita empate gana eq1 si hay empate

CREATE OR REPLACE TRIGGER tri_noEmpate AFTER INSERT OR UPDATE OF par_estado ON partido FOR EACH ROW
DECLARE
BEGIN
    IF :NEW.par_estado = 'Finalizado' AND :NEW.par_golesequ1 = :NEW.par_golesequ2 THEN
        UPDATE partido SET par_golesequ1 = :NEW.par_golesequ1 + 1 WHERE par_id = :NEW.par_id;
    END IF;
END;

-- Procedimientos

CREATE OR REPLACE PROCEDURE pro_borrarPorMinComision (prm_comisionMinima jugador.jug_comision%TYPE)
IS
    CURSOR cur_jugadores IS SELECT jug_cedula, Jug_fechaIngreEqu FROM jugador WHERE jug_comision < prm_comisionMinima;
    reg_jugadores cur_jugadores%ROWTYPE;
    
    var_date2YAntes DATE;
BEGIN
    SELECT add_months(to_date(SYSDATE), -24) INTO var_date2YAntes FROM DUAL;
    OPEN cur_jugadores;
    LOOP
        FETCH cur_jugadores INTO reg_jugadores;
        EXIT WHEN cur_jugadores%NOTFOUND OR
                  cur_jugadores%NOTFOUND IS NULL;
        IF var_date2YAntes > reg_jugadores.Jug_fechaIngreEqu THEN
            DELETE FROM tarjetajugador WHERE tarjetajugador.jug_cedula = reg_jugadores.jug_cedula;
            DELETE FROM jugador WHERE jugador.jug_cedula = reg_jugadores.jug_cedula;
        END IF;
    END LOOP;
    CLOSE cur_jugadores;
END;

CREATE OR REPLACE PROCEDURE pro_inhabilitarJugConTarjetas
IS
    CURSOR cur_jugadores IS SELECT jug_cedula, jug_estado, numtarjetas FROM jugador 
        INNER JOIN (SELECT jug_cedula AS cedula, COUNT(tar_id) AS numtarjetas FROM tarjetaJugador GROUP BY jug_cedula) ON jug_cedula = cedula
    WHERE numtarjetas >= 3;
    reg_jugadores cur_jugadores%ROWTYPE;
BEGIN
    OPEN cur_jugadores;
    LOOP
        FETCH cur_jugadores INTO reg_jugadores;
        EXIT WHEN cur_jugadores%NOTFOUND OR
                  cur_jugadores%NOTFOUND IS NULL;
        IF reg_jugadores.jug_estado = 'Habilitado' THEN
            UPDATE jugador SET jug_estado = 'Inhabilitado' WHERE reg_jugadores.jug_cedula = jugador.jug_cedula; 
        END IF;
    END LOOP;
    CLOSE cur_jugadores;
END;

CREATE OR REPLACE PROCEDURE agregarBonusPorVeterania
IS
    CURSOR cur_jugadores IS SELECT jug_cedula, jug_comision FROM jugador WHERE Jug_fechaIngreEqu <= (SELECT add_months(to_date(SYSDATE), -60) 
                                                            FROM DUAL);
    reg_jugadores cur_jugadores%ROWTYPE;
BEGIN
    OPEN cur_jugadores;
    LOOP
        FETCH cur_jugadores INTO reg_jugadores;
        EXIT WHEN cur_jugadores%NOTFOUND OR
                  cur_jugadores%NOTFOUND IS NULL;
        IF reg_jugadores.jug_comision < 50 THEN
            UPDATE jugador SET jug_comision = (reg_jugadores.jug_comision + 5) WHERE reg_jugadores.jug_cedula = jugador.jug_cedula; 
        END IF;
    END LOOP;
    CLOSE cur_jugadores;
END;

CREATE OR REPLACE PROCEDURE aumentarSueldo (prm_porcentaje NUMBER, prm_equipo equipo.equ_id%TYPE)
IS
    CURSOR cur_jugadores IS SELECT jug_cedula, jug_sueldo FROM jugador WHERE equ_id = prm_equipo;
    reg_jugadores cur_jugadores%ROWTYPE;
    
    var_totalgastos NUMBER := 0;
    var_nuevosueldo NUMBER := 0;
BEGIN
    SAVEPOINT limiteExcedido;
    OPEN cur_jugadores;
    LOOP
        FETCH cur_jugadores INTO reg_jugadores;
        EXIT WHEN cur_jugadores%NOTFOUND OR
                  cur_jugadores%NOTFOUND IS NULL;
        var_nuevosueldo := reg_jugadores.jug_sueldo + (reg_jugadores.jug_sueldo * (prm_porcentaje / 100));
        var_totalgastos := var_totalgastos + var_nuevosueldo;
        UPDATE jugador SET jug_sueldo = var_nuevosueldo WHERE reg_jugadores.jug_cedula = jugador.jug_cedula;
    END LOOP;
    CLOSE cur_jugadores;
    IF var_totalgastos >= 1000000000 THEN
        ROLLBACK TO SAVEPOINT limiteExcedido;
    END IF;
END;

---------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------

                                          /*Automatizacion clasifica*/

CREATE OR REPLACE PACKAGE pck_globalvars
IS
    var_mesaumento NUMBER := 0;
END;

CREATE OR REPLACE PROCEDURE pro_autoCuartos(prm_torid NUMBER, prm_equ1 NUMBER, prm_equ2 NUMBER, prm_equ3 NUMBER, prm_equ4 NUMBER, prm_equ5 NUMBER, 
                                            prm_equ6 NUMBER, prm_equ7 NUMBER, prm_equ8 NUMBER)
IS
    var_parid NUMBER := prm_torid * 10;
    var_cancha NUMBER := 0;
    var_fecha DATE;
    var_gol1 NUMBER;
    var_gol2 NUMBER;
BEGIN
    --Cancha aleatoria para cd partido
    SELECT can_id INTO var_cancha FROM cancha ORDER BY dbms_random.random FETCH FIRST 1 ROW ONLY;
    SELECT (SYSDATE + 2) INTO var_fecha FROM DUAL;
    SELECT ROUND(DBMS_RANDOM.VALUE(1,20)), ROUND(DBMS_RANDOM.VALUE(1,20)) INTO var_gol1, var_gol2 FROM dual;
    pro_crearPartido((var_parid + 1), var_cancha, prm_torid, (var_fecha + pck_globalvars.var_mesaumento), var_gol1, var_gol2, 'Cuartos', 
                                                              2000, 10000, 'Activo');
        pro_generarJuega((var_parid + 1), prm_equ1, 1);
        pro_generarJuega((var_parid + 1), prm_equ2, 2);
    SELECT can_id INTO var_cancha FROM cancha ORDER BY dbms_random.random FETCH FIRST 1 ROW ONLY;
    SELECT (SYSDATE + 4) INTO var_fecha FROM DUAL;
    SELECT ROUND(DBMS_RANDOM.VALUE(1,20)), ROUND(DBMS_RANDOM.VALUE(1,20)) INTO var_gol1, var_gol2 FROM dual;
    pro_crearPartido((var_parid + 2), var_cancha, prm_torid, (var_fecha + pck_globalvars.var_mesaumento), var_gol1, var_gol2, 'Cuartos', 
                                                              2000, 10000, 'Activo');
        pro_generarJuega((var_parid + 2), prm_equ3, 1);
        pro_generarJuega((var_parid + 2), prm_equ4, 2);
    SELECT can_id INTO var_cancha FROM cancha ORDER BY dbms_random.random FETCH FIRST 1 ROW ONLY;
    SELECT (SYSDATE + 6) INTO var_fecha FROM DUAL;
    SELECT ROUND(DBMS_RANDOM.VALUE(1,20)), ROUND(DBMS_RANDOM.VALUE(1,20)) INTO var_gol1, var_gol2 FROM dual;
    pro_crearPartido((var_parid + 3), var_cancha, prm_torid, (var_fecha + pck_globalvars.var_mesaumento), var_gol1, var_gol2, 'Cuartos', 
                                                              2000, 10000, 'Activo');
        pro_generarJuega((var_parid + 3), prm_equ5, 1);
        pro_generarJuega((var_parid + 3), prm_equ6, 2);
    SELECT can_id INTO var_cancha FROM cancha ORDER BY dbms_random.random FETCH FIRST 1 ROW ONLY;
    SELECT (SYSDATE + 8) INTO var_fecha FROM DUAL;
    SELECT ROUND(DBMS_RANDOM.VALUE(1,20)), ROUND(DBMS_RANDOM.VALUE(1,20)) INTO var_gol1, var_gol2 FROM dual;
    pro_crearPartido((var_parid + 4), var_cancha, prm_torid, (var_fecha + pck_globalvars.var_mesaumento), var_gol1, var_gol2, 'Cuartos', 
                                                              2000, 10000, 'Activo');
        pro_generarJuega((var_parid + 4), prm_equ7, 1);
        pro_generarJuega((var_parid + 4), prm_equ8, 2);
END;

CREATE OR REPLACE PROCEDURE pro_autoSemiFinal(prm_torid NUMBER)
IS
    var_parid NUMBER := prm_torid * 10;
    var_cancha NUMBER := 0;
    var_fecha DATE;
    var_gol1 NUMBER;
    var_gol2 NUMBER;
BEGIN
    UPDATE partido SET par_estado = 'Finalizado' WHERE par_id = ((prm_torid * 10) + 1);
    UPDATE partido SET par_estado = 'Finalizado' WHERE par_id = ((prm_torid * 10) + 2);
    UPDATE partido SET par_estado = 'Finalizado' WHERE par_id = ((prm_torid * 10) + 3);
    UPDATE partido SET par_estado = 'Finalizado' WHERE par_id = ((prm_torid * 10) + 4);
    SELECT can_id INTO var_cancha FROM cancha ORDER BY dbms_random.random FETCH FIRST 1 ROW ONLY;
    SELECT (SYSDATE + 10) INTO var_fecha FROM DUAL;
    SELECT ROUND(DBMS_RANDOM.VALUE(1,20)), ROUND(DBMS_RANDOM.VALUE(1,20)) INTO var_gol1, var_gol2 FROM dual;
    pro_crearPartido((var_parid + 5), var_cancha, prm_torid, (var_fecha + pck_globalvars.var_mesaumento), var_gol1, var_gol2, 'SemiFinal', 2000, 10000, 'Activo');
        pro_generarJuega((var_parid + 5), fun_obtenerGanador((var_parid + 1)), 1);
        pro_generarJuega((var_parid + 5), fun_obtenerGanador((var_parid + 2)), 2);
    SELECT can_id INTO var_cancha FROM cancha ORDER BY dbms_random.random FETCH FIRST 1 ROW ONLY;
    SELECT (SYSDATE + 12) INTO var_fecha FROM DUAL;
    SELECT ROUND(DBMS_RANDOM.VALUE(1,20)), ROUND(DBMS_RANDOM.VALUE(1,20)) INTO var_gol1, var_gol2 FROM dual;
    pro_crearPartido((var_parid + 6), var_cancha, prm_torid, (var_fecha + pck_globalvars.var_mesaumento), var_gol1, var_gol2, 'SemiFinal', 2000, 10000, 'Activo');
        pro_generarJuega((var_parid + 6), fun_obtenerGanador((var_parid + 3)), 1);
        pro_generarJuega((var_parid + 6), fun_obtenerGanador((var_parid + 4)), 2);
END;

CREATE OR REPLACE PROCEDURE pro_autoFinal (prm_torid NUMBER)
IS
    var_parid NUMBER := prm_torid * 10;
    var_cancha NUMBER := 0;
    var_fecha DATE;
    var_gol1 NUMBER;
    var_gol2 NUMBER;
BEGIN
    UPDATE partido SET par_estado = 'Finalizado' WHERE par_id = ((prm_torid * 10) + 5);
    UPDATE partido SET par_estado = 'Finalizado' WHERE par_id = ((prm_torid * 10) + 6);
    SELECT can_id INTO var_cancha FROM cancha ORDER BY dbms_random.random FETCH FIRST 1 ROW ONLY;
    SELECT (SYSDATE + 12) INTO var_fecha FROM DUAL;
    SELECT ROUND(DBMS_RANDOM.VALUE(1,20)), ROUND(DBMS_RANDOM.VALUE(1,20)) INTO var_gol1, var_gol2 FROM dual;
    pro_crearPartido((var_parid + 7), var_cancha, prm_torid, (var_fecha + pck_globalvars.var_mesaumento), var_gol1, var_gol2, 'Final', 
                                                              2000, 10000, 'Activo');
        pro_generarJuega((var_parid + 7), fun_obtenerGanador((var_parid + 5)), 1);
        pro_generarJuega((var_parid + 7), fun_obtenerGanador((var_parid + 6)), 2);
    UPDATE partido SET par_estado = 'Finalizado' WHERE par_id = ((prm_torid * 10) + 7);
    pck_globalvars.var_mesaumento := 0;
END;

CREATE OR REPLACE PROCEDURE pro_generarJuega(prm_parid NUMBER, prm_teamid NUMBER, prm_como NUMBER)
IS
BEGIN
    INSERT INTO EQUIPOPARTIDO VALUES (prm_parid, prm_teamid, prm_como);
END;--

--RESTRINCCIONES EN TABLAS
    ALTER TABLE EQUIPOPARTIDO ADD CONSTRAINT chk_juecomo CHECK (jue_como IN (1, 2));
    ALTER TABLE partido ADD CONSTRAINT chk_parestado CHECK (par_estado IN ('Activo', 'Finalizado'));
    ALTER TABLE jugador ADD CONSTRAINT cjk_jugcomo CHECK (jug_estado IN ('Habilitado', 'Inhabilitado'));


--SELECT y pruebas

    --Almacena y muestra los jugadores y los goles que a maracado, ordenandolos por los goles (prm_equid equipo.equ_id%TYPE)
    SELECT jug_nombre, jug_numgoles FROM jugador WHERE equ_id = prm_equid ORDER BY jug_numgoles;
    
    --Almacene y filtre los jugadores con más goles por equipo.
    SELECT jug_nombre, goles, equ_nombre FROM jugador
        INNER JOIN (SELECT jug_cedula AS cedula, MAX(jug_numgoles) AS goles FROM jugador group by jug_cedula) ON jugador.jug_cedula = cedula
        INNER JOIN equipo ON jugador.equ_id = equipo.equ_id;
    
    --Almacene y filtre los jugadores mejor pagados por equipo (sueldo, para considerar la comision debe aplicarse en un procedimiento).
    SELECT jug_nombre, sueldo, equ_nombre FROM jugador
        INNER JOIN (SELECT jug_cedula AS cedula, MAX(jug_sueldo) AS sueldo FROM jugador group by jug_cedula) ON jugador.jug_cedula = cedula
        INNER JOIN equipo ON jugador.equ_id = equipo.equ_id;
    
    --Almacene y filtre las (10) canchas con más partidos disputados en ella.
    SELECT can_nombre, count(par_id) AS num_canchas FROM partido INNER JOIN cancha ON partido.can_id = cancha.can_id  
                                      GROUP BY can_nombre ORDER BY num_canchas FETCH FIRST 10 ROWS ONLY ;
     
    --Almacene la información de los equipos y sus respectivos torneos en los que hayan jugado para posteriormente mostrarlo.
    SELECT equipo.*, tor_nombre FROM equipo INNER JOIN juega ON equipo.equ_id = juega.equ_id INNER JOIN partido ON juega.par_id = partido.par_id
                                            INNER JOIN torneo ON partido.tor_id = torneo.tor_id;
    
    --Almacene y filtre los jugadores con más tarjetas de cada equipo registrado.
    SELECT jug_nombre, equ_nombre, tarjetas FROM jugador
        INNER JOIN (SELECT cedula, MAX(num_tarjetas) AS tarjetas FROM (SELECT jug_cedula AS cedula, COUNT(tar_id) AS num_tarjetas FROM tienetarjeta group by jug_cedula) group by cedula) ON jugador.jug_cedula = cedula
        INNER JOIN equipo ON jugador.equ_id = equipo.equ_id;

--Jugador mas tarjetas

SELECT jug_nombre, equ_nombre, tarjetas FROM jugador
        INNER JOIN (SELECT cedula, MAX(num_tarjetas) AS tarjetas FROM (SELECT jug_cedula AS cedula, COUNT(tar_id) AS num_tarjetas FROM tarjetajugador group by jug_cedula) group by cedula) ON jugador.jug_cedula = cedula
        INNER JOIN equipo ON jugador.equ_id = equipo.equ_id;

--arqueros menos goles

SELECT jug_nombre, jug_numgoles AS goles_tapados FROM jugador WHERE jug_posicionjue = 'Arquero' ORDER BY jug_numgoles DESC FETCH FIRST 10 ROWS ONLY;

--top 10 partidos con mas entradas vendidas

SELECT par_id, par_numentradavends FROM partido ORDER BY par_numentradavends DESC FETCH FIRST 10 ROWS ONLY;