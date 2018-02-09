SELECT p.ProjectNotes, SUM(p.TransactionValue) from Purchase p
INNER JOIN Cardholder c on c.CardholderID = p.CardholderID
INNER JOIN Department d on d.DepartmentID = c.DepartmentID
Where d.Name = 'Public Works' and d.Division = 'Maintenance' and (p.Posted BETWEEN '07-01-2013' AND GETDATE())
GROUP BY CUBE (ProjectNotes)