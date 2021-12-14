-- SEQUENCE: BluRayTheque.Acteur_Id_seq

-- DROP SEQUENCE IF EXISTS "BluRayTheque"."Acteur_Id_seq";

CREATE SEQUENCE IF NOT EXISTS "BluRayTheque"."Acteur_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1
    OWNED BY "Acteur"."Id";

ALTER SEQUENCE "BluRayTheque"."Acteur_Id_seq"
    OWNER TO postgres;

-- SEQUENCE: BluRayTheque.BluRayLangue_Id_seq

-- DROP SEQUENCE IF EXISTS "BluRayTheque"."BluRayLangue_Id_seq";

CREATE SEQUENCE IF NOT EXISTS "BluRayTheque"."BluRayLangue_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1
    OWNED BY "BluRayLangue"."Id";

ALTER SEQUENCE "BluRayTheque"."BluRayLangue_Id_seq"
    OWNER TO postgres;

-- SEQUENCE: BluRayTheque.BluRaySsTitre_Id_seq

-- DROP SEQUENCE IF EXISTS "BluRayTheque"."BluRaySsTitre_Id_seq";

CREATE SEQUENCE IF NOT EXISTS "BluRayTheque"."BluRaySsTitre_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1
    OWNED BY "BluRaySsTitre"."Id";

ALTER SEQUENCE "BluRayTheque"."BluRaySsTitre_Id_seq"
    OWNER TO postgres;

-- SEQUENCE: BluRayTheque.BluRay_Id_seq

-- DROP SEQUENCE IF EXISTS "BluRayTheque"."BluRay_Id_seq";

CREATE SEQUENCE IF NOT EXISTS "BluRayTheque"."BluRay_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1
    OWNED BY "BluRay"."Id";

ALTER SEQUENCE "BluRayTheque"."BluRay_Id_seq"
    OWNER TO postgres;

-- SEQUENCE: BluRayTheque.Personne_Id_seq

-- DROP SEQUENCE IF EXISTS "BluRayTheque"."Personne_Id_seq";

CREATE SEQUENCE IF NOT EXISTS "BluRayTheque"."Personne_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1
    OWNED BY "Personne"."Id";

ALTER SEQUENCE "BluRayTheque"."Personne_Id_seq"
    OWNER TO postgres;

-- SEQUENCE: BluRayTheque.Realisateur_Id_seq

-- DROP SEQUENCE IF EXISTS "BluRayTheque"."Realisateur_Id_seq";

CREATE SEQUENCE IF NOT EXISTS "BluRayTheque"."Realisateur_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1
    OWNED BY "Realisateur"."Id";

ALTER SEQUENCE "BluRayTheque"."Realisateur_Id_seq"
    OWNER TO postgres;

-- SEQUENCE: BluRayTheque.RefLangue_Id_seq

-- DROP SEQUENCE IF EXISTS "BluRayTheque"."RefLangue_Id_seq";

CREATE SEQUENCE IF NOT EXISTS "BluRayTheque"."RefLangue_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1
    OWNED BY "RefLangue"."Id";

ALTER SEQUENCE "BluRayTheque"."RefLangue_Id_seq"
    OWNER TO postgres;

-- SEQUENCE: BluRayTheque.Scenariste_Id_seq

-- DROP SEQUENCE IF EXISTS "BluRayTheque"."Scenariste_Id_seq";

CREATE SEQUENCE IF NOT EXISTS "BluRayTheque"."Scenariste_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1
    OWNED BY "Scenariste"."Id";

ALTER SEQUENCE "BluRayTheque"."Scenariste_Id_seq"
    OWNER TO postgres;