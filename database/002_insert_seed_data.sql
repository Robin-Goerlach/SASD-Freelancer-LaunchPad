-- SASD Freelancer LaunchPad
-- Initial seed data for first application startup.

INSERT OR IGNORE INTO platforms (name, base_url, notes, is_active, created_at, updated_at)
VALUES
('PeoplePerHour', 'https://www.peopleperhour.com', 'Primary platform for early project tracking.', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('Freelancermap', 'https://www.freelancermap.de', 'Possible later platform.', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('Manual', NULL, 'Manually entered project source.', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT OR IGNORE INTO skills (name, normalized_name, notes, is_active, created_at, updated_at)
VALUES
('Linux', 'linux', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('PHP', 'php', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('MariaDB', 'mariadb', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('MySQL', 'mysql', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('SQLite', 'sqlite', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('C#', 'c#', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('Windows Forms', 'windows forms', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('REST API', 'rest api', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('Server Migration', 'server migration', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
