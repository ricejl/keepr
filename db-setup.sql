USE keepadb;

-- CREATE TABLE vaults (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     INDEX userId (userId),  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE keeps (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     img VARCHAR(255),
--     isPrivate TINYINT,
--     views INT DEFAULT 0,
--     shares INT DEFAULT 0,
--     keeps INT DEFAULT 0,
--     INDEX userId (userId),
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE vaultkeeps (
--     id int NOT NULL AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (vaultId, keepId),
--     INDEX (userId),

--     FOREIGN KEY (vaultId)
--         REFERENCES vaults(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (keepId)
--         REFERENCES keeps(id)
--         ON DELETE CASCADE
-- )

-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT k.* FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 

-- DELETE FROM keeps;
-- DELETE FROM vaults;
-- DELETE FROM vaultkeeps;

-- -- USE THIS TO CLEAN OUT YOUR DATABASE
-- DROP TABLE IF EXISTS vaultkeeps;
-- DROP TABLE IF EXISTS vaults;
-- DROP TABLE IF EXISTS keeps;
-- DROP TABLE IF EXISTS users;


-- NOTE manually created keep
-- INSERT INTO keeps (userId, name, description, img, isPrivate, views, shares, keeps)
-- VALUES ("google-oauth2|114958310870048847241", "manual keep", "manual keep description", "//placehold.it/200x200", 0, 0, 0, 0);
-- SELECT LAST_INSERT_ID();

-- NOTE manually created vault
-- INSERT INTO vaults (name, description, userId)
-- VALUES ("manual vault", "manually created vault", "google-oauth2|114958310870048847241");
-- SELECT LAST_INSERT_ID()";
