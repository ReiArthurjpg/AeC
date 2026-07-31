-- Senha padrão: Admin@123. O hash abaixo é BCrypt e deve ser substituído em produção.
IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Usuario = 'admin')
BEGIN
    INSERT INTO Usuarios (Nome, Usuario, Senha) VALUES ('Administrador', 'admin', '$2a$11$cMlDNb2sBfhW5omphA2Vu.lb82aeMl/Rq51n0NwxxjtEEa.Hm/Le2');
END
