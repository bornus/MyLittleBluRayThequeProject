CREATE OR REPLACE FUNCTION "BluRayTheque"."GetActeursByBRId"(IN "brid" bigInt, IN OUT cur refcursor) RETURNS refcursor AS $$
    BEGIN
	    OPEN cur FOR
			Select per."Id", per."Nom", per."Prenom", per."DateNaissance", per."Nationalite"
			 from "BluRayTheque"."Acteur" as r
				  INNER JOIN "BluRayTheque"."Personne" as per
				ON per."Id" = r."IdActeur"
			where r."IdBluRay" = brid;
    END;
    $$ LANGUAGE plpgsql;