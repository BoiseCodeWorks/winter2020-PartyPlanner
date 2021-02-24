-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE parties
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL UNIQUE,

--   PRIMARY KEY (id),

--   -- REVIEW[epic=Populate] Establishing a relationship to a foreign key
--   FOREIGN KEY (creatorId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE
-- );

-- CREATE TABLE partymembers
-- (
--    id INT NOT NULL AUTO_INCREMENT,
--    memberId VARCHAR(255) NOT NULL,
--    partyId INT NOT NULL,

--   PRIMARY KEY (id),

--   -- REVIEW[epic=many-to-many] Establishing a relationship to a foreign key
--   FOREIGN KEY (memberId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE,

--   -- REVIEW[epic=many-to-many] Establishing a relationship to a foreign key
--   FOREIGN KEY (partyId)
--    REFERENCES parties (id)
--    ON DELETE CASCADE
-- );