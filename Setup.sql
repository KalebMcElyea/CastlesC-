
-- USE castleandknights;

-- DROP TABLE castle;

CREATE TABLE castle(
  id INT NOT NULL AUTO_INCREMENT,
  king VARCHAR(255) NOT NULL,
  country VARCHAR(255),
  name  VARCHAR(75),

  PRIMARY KEY (id)
);



-- TRUNCATE TABLE artists
-- to clear out the data and then you can make with correct columns


-- ALTER TABLE artists
-- DROP COLUMN bio;


-- CREATE TABLE knight
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   age INT NOT NULL,
--   castleId INT NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (castleId)
--     REFERENCES castle (id)
--     ON DELETE CASCADE
-- )