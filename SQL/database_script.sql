
alter table CANCHA
   drop constraint FK_CANCHA_CANCHAUBI_UBICACIO;

alter table EQUIPOPARTIDO
   drop constraint FK_EQUIPOPA_EQUIPOPAR_EQUIPO;

alter table EQUIPOPARTIDO
   drop constraint FK_EQUIPOPA_EQUIPOPAR_PARTIDO;

alter table EQUIPOTORNEO
   drop constraint FK_EQUIPOTO_EQUIPOTOR_EQUIPO;

alter table EQUIPOTORNEO
   drop constraint FK_EQUIPOTO_EQUIPOTOR_TORNEO;

alter table JUGADOR
   drop constraint FK_JUGADOR_JUGADOREQ_EQUIPO;

alter table PARTIDO
   drop constraint FK_PARTIDO_PARTIDOCA_CANCHA;

alter table PARTIDO
   drop constraint FK_PARTIDO_TORNEOPAR_TORNEO;

alter table TARJETAJUGADOR
   drop constraint FK_TARJETAJ_TARJETAJU_TARJETA;

alter table TARJETAJUGADOR
   drop constraint FK_TARJETAJ_TARJETAJU_JUGADOR;

alter table TARJETAJUGADOR
   drop constraint FK_TARJETAJ_TARJETAJU_PARTIDO;

drop index TIENE3_FK;

drop table CANCHA cascade constraints;

drop table EQUIPO cascade constraints;

drop index JUEGA2_FK;

drop index JUEGA_FK;

drop table EQUIPOPARTIDO cascade constraints;

drop index CLASIFICA2_FK;

drop index CLASIFICA_FK;

drop table EQUIPOTORNEO cascade constraints;

drop index TIENE_FK;

drop table JUGADOR cascade constraints;

drop index PERTENECEN_FK;

drop index DISPUTADO_FK;

drop table PARTIDO cascade constraints;

drop table TARJETA cascade constraints;

drop index TARJETAJUGADOR3_FK;

drop index TARJETAJUGADOR2_FK;

drop index TARJETAJUGADOR_FK;

drop table TARJETAJUGADOR cascade constraints;

drop table TORNEO cascade constraints;

drop table UBICACION cascade constraints;

/*==============================================================*/
/* Table: CANCHA                                                */
/*==============================================================*/
create table CANCHA 
(
   CAN_ID               INTEGER              not null,
   UBI_ID               INTEGER,
   CAN_NOMBRE           VARCHAR2(40),
   constraint PK_CANCHA primary key (CAN_ID)
);

/*==============================================================*/
/* Index: TIENE3_FK                                             */
/*==============================================================*/
create index TIENE3_FK on CANCHA (
   UBI_ID ASC
);

/*==============================================================*/
/* Table: EQUIPO                                                */
/*==============================================================*/
create table EQUIPO 
(
   EQU_ID               INTEGER              not null,
   EQU_NOMBRE           VARCHAR2(40),
   EQU_REPRESENTA       VARCHAR2(40),
   EQU_GOLES            INTEGER,
   constraint PK_EQUIPO primary key (EQU_ID)
);

/*==============================================================*/
/* Table: EQUIPOPARTIDO                                         */
/*==============================================================*/
create table EQUIPOPARTIDO 
(
   EQU_ID               INTEGER              not null,
   PAR_ID               INTEGER              not null,
   JUE_COMO             INTEGER,
);

/*==============================================================*/
/* Index: JUEGA_FK                                              */
/*==============================================================*/
create index JUEGA_FK on EQUIPOPARTIDO (
   PAR_ID ASC
);

/*==============================================================*/
/* Index: JUEGA2_FK                                             */
/*==============================================================*/
create index JUEGA2_FK on EQUIPOPARTIDO (
   EQU_ID ASC
);

/*==============================================================*/
/* Table: EQUIPOTORNEO                                          */
/*==============================================================*/
create table EQUIPOTORNEO 
(
   EQU_ID               INTEGER              not null,
   TOR_ID               INTEGER              not null,
);

/*==============================================================*/
/* Index: CLASIFICA_FK                                          */
/*==============================================================*/
create index CLASIFICA_FK on EQUIPOTORNEO (
   EQU_ID ASC
);

/*==============================================================*/
/* Index: CLASIFICA2_FK                                         */
/*==============================================================*/
create index CLASIFICA2_FK on EQUIPOTORNEO (
   TOR_ID ASC
);

/*==============================================================*/
/* Table: JUGADOR                                               */
/*==============================================================*/
create table JUGADOR 
(
   JUG_CEDULA           INTEGER              not null,
   EQU_ID               INTEGER,
   JUG_NOMBRE           VARCHAR2(40),
   JUG_NUMGOLES         INTEGER,
   JUG_SUELDO           INTEGER,
   JUG_POSICIONJUE      VARCHAR2(30),
   JUG_COMISION         INTEGER,
   JUG_ESTADO           VARCHAR2(20),
   JUG_FECHAINGREEQU    DATE,
   constraint PK_JUGADOR primary key (JUG_CEDULA)
);

/*==============================================================*/
/* Index: TIENE_FK                                              */
/*==============================================================*/
create index TIENE_FK on JUGADOR (
   EQU_ID ASC
);

/*==============================================================*/
/* Table: PARTIDO                                               */
/*==============================================================*/
create table PARTIDO 
(
   PAR_ID               INTEGER              not null,
   CAN_ID               INTEGER,
   TOR_ID               INTEGER,
   PAR_FECHA            DATE,
   PAR_GOLESEQU1        INTEGER,
   PAR_GOLESEQU2        INTEGER,
   PAR_TIPO             VARCHAR2(30)         not null,
   PAR_NUMENTRADAVENDS  INTEGER,
   PAR_PRECIOENTRADAS   INTEGER,
   PAR_ESTADO           VARCHAR2(30),
   constraint PK_PARTIDO primary key (PAR_ID)
);

/*==============================================================*/
/* Index: DISPUTADO_FK                                          */
/*==============================================================*/
create index DISPUTADO_FK on PARTIDO (
   CAN_ID ASC
);

/*==============================================================*/
/* Index: PERTENECEN_FK                                         */
/*==============================================================*/
create index PERTENECEN_FK on PARTIDO (
   TOR_ID ASC
);

/*==============================================================*/
/* Table: TARJETA                                               */
/*==============================================================*/
create table TARJETA 
(
   TAR_ID               INTEGER              not null,
   TAR_TIPO             VARCHAR2(20),
   constraint PK_TARJETA primary key (TAR_ID)
);

/*==============================================================*/
/* Table: TARJETAJUGADOR                                        */
/*==============================================================*/
create table TARJETAJUGADOR 
(
   TAR_ID               INTEGER              not null,
   JUG_CEDULA           INTEGER              not null,
   PAR_ID               INTEGER              not null,
);

/*==============================================================*/
/* Index: TARJETAJUGADOR_FK                                     */
/*==============================================================*/
create index TARJETAJUGADOR_FK on TARJETAJUGADOR (
   TAR_ID ASC
);

/*==============================================================*/
/* Index: TARJETAJUGADOR2_FK                                    */
/*==============================================================*/
create index TARJETAJUGADOR2_FK on TARJETAJUGADOR (
   JUG_CEDULA ASC
);

/*==============================================================*/
/* Index: TARJETAJUGADOR3_FK                                    */
/*==============================================================*/
create index TARJETAJUGADOR3_FK on TARJETAJUGADOR (
   PAR_ID ASC
);

/*==============================================================*/
/* Table: TORNEO                                                */
/*==============================================================*/
create table TORNEO 
(
   TOR_ID               INTEGER              not null,
   TOR_NOMBRE           VARCHAR2(40),
   constraint PK_TORNEO primary key (TOR_ID)
);

/*==============================================================*/
/* Table: UBICACION                                             */
/*==============================================================*/
create table UBICACION 
(
   UBI_ID               INTEGER              not null,
   UBI_DIRECCION        VARCHAR2(40),
   UBI_CIUDAD           VARCHAR2(40),
   constraint PK_UBICACION primary key (UBI_ID)
);

alter table CANCHA
   add constraint FK_CANCHA_CANCHAUBI_UBICACIO foreign key (UBI_ID)
      references UBICACION (UBI_ID);

alter table EQUIPOPARTIDO
   add constraint FK_EQUIPOPA_EQUIPOPAR_EQUIPO foreign key (EQU_ID)
      references EQUIPO (EQU_ID);

alter table EQUIPOPARTIDO
   add constraint FK_EQUIPOPA_EQUIPOPAR_PARTIDO foreign key (PAR_ID)
      references PARTIDO (PAR_ID);

alter table EQUIPOTORNEO
   add constraint FK_EQUIPOTO_EQUIPOTOR_EQUIPO foreign key (EQU_ID)
      references EQUIPO (EQU_ID);

alter table EQUIPOTORNEO
   add constraint FK_EQUIPOTO_EQUIPOTOR_TORNEO foreign key (TOR_ID)
      references TORNEO (TOR_ID);

alter table JUGADOR
   add constraint FK_JUGADOR_JUGADOREQ_EQUIPO foreign key (EQU_ID)
      references EQUIPO (EQU_ID);

alter table PARTIDO
   add constraint FK_PARTIDO_PARTIDOCA_CANCHA foreign key (CAN_ID)
      references CANCHA (CAN_ID);

alter table PARTIDO
   add constraint FK_PARTIDO_TORNEOPAR_TORNEO foreign key (TOR_ID)
      references TORNEO (TOR_ID);

alter table TARJETAJUGADOR
   add constraint FK_TARJETAJ_TARJETAJU_TARJETA foreign key (TAR_ID)
      references TARJETA (TAR_ID);

alter table TARJETAJUGADOR
   add constraint FK_TARJETAJ_TARJETAJU_JUGADOR foreign key (JUG_CEDULA)
      references JUGADOR (JUG_CEDULA);

alter table TARJETAJUGADOR
   add constraint FK_TARJETAJ_TARJETAJU_PARTIDO foreign key (PAR_ID)
      references PARTIDO (PAR_ID);

