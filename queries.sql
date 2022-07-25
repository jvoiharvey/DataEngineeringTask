 
  SELECT TOP(1) A.[region],A.[DATASOURCE],MAX(A.[date_time2]) AS [LATEST] from [JevoiPractice].[dbo].[trips2] A INNER JOIN
  
  (SELECT TOP(2) [Region]
      ,COUNT(*) AS [TOTAL]
  FROM [JevoiPractice].[dbo].[trips2] GROUP BY [REGION]) B ON A.[REGION] = B.[REGION]

  GROUP BY A.[region],A.[DataSource]
  ORDER BY MAX(A.[date_time2]) DESC

GO

SELECT DISTINCT A.[REGION] 

FROM [JevoiPractice].[dbo].[trips2] A WHERE [DATASOURCE] = 'cheap_mobile'