SELECT 
                            e.Id IdEjecutivo,
                            e.Nombre + ' ' + e.Apellido AS Ejecutivo,
                            COUNT(DISTINCT v.Id) AS TotalVisitas,
                            COUNT(DISTINCT c.Id) AS ClientesAtendidos,
                            COUNT(DISTINCT ve.Id) AS TotalVentas,
                            ISNULL(SUM(ve.Monto), 0) AS MontoTotalVentas
                        FROM Ejecutivos e
                        LEFT JOIN Visitas v ON e.Id = v.IdEjecutivo
                        LEFT JOIN Clientes c ON v.IdCliente = c.Id
                        LEFT JOIN Ventas ve ON c.Id = ve.IdCliente
                        GROUP BY e.Id, e.Nombre, e.Apellido
                        ORDER BY MontoTotalVentas DESC