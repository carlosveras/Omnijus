
IF OBJECT_ID(N'tempdb..#analiseTimSulAmerica') IS NOT NULL
BEGIN
DROP TABLE #analiseTimSulAmerica
END
GO

CREATE TABLE #analiseTimSulAmerica 
(
Cliente            [varchar](100) NULL,
Numero             [varchar](30) NULL,
NumeroEncontrado   [varchar](30) NULL,
IdTribunalJustica  [int] NULL,
StatusProcesso     [smallint] NULL,
DescrStatusProcesso[varchar](50) NULL,
StatusCaptura      [smallint] NULL,
DescrStatusCaptura [varchar](50) NULL,
IdProcesso         [int] NULL,
Nome               [varchar](250) NULL,
Qualificacao       [varchar](100) NULL,
NomeAdvogado       [varchar](250) NULL,
Expressao          [varchar](200) NULL,
)

insert into #analiseTimSulAmerica
(Cliente,Numero, NumeroEncontrado, IdTribunalJustica, StatusProcesso, DescrStatusProcesso, 
  StatusCaptura, DescrStatusCaptura, IdProcesso, Nome, Qualificacao, NomeAdvogado, Expressao)
Values 
('SULAMERICA','0000006-19.2021.5.05.0030','','','','','','','','','','',''),
('SULAMERICA','0000032-40.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000052-55.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','0000053-58.2021.8.26.0191','','','','','','','','','','',''),
('SULAMERICA','0000055-83.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000056-68.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000057-38.2021.8.26.0016','','','','','','','','','','',''),
('SULAMERICA','0000088-93.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','0000095-65.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000109-92.2021.8.26.0223','','','','','','','','','','',''),
('SULAMERICA','0000138-02.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000140-27.2021.8.26.0704','','','','','','','','','','',''),
('SULAMERICA','0000142-23.2021.8.26.0566','','','','','','','','','','',''),
('SULAMERICA','0000145-91.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000147-06.2021.8.26.0482','','','','','','','','','','',''),
('SULAMERICA','0000165-85.2021.8.26.0010','','','','','','','','','','',''),
('SULAMERICA','0000168-52.2021.8.26.0006','','','','','','','','','','',''),
('SULAMERICA','0000190-95.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000196-05.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000198-72.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000203-94.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000207-34.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000216-93.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000217-04.2021.8.26.0068','','','','','','','','','','',''),
('SULAMERICA','0000249-83.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000255-14.2021.8.26.0004','','','','','','','','','','',''),
('SULAMERICA','0000256-08.2021.8.26.0001','','','','','','','','','','',''),
('SULAMERICA','0000271-44.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000272-29.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','0000285-62.2021.8.26.0032','','','','','','','','','','',''),
('SULAMERICA','0000359-96.2021.8.26.0071','','','','','','','','','','',''),
('SULAMERICA','0000421-39.2021.8.26.0071','','','','','','','','','','',''),
('SULAMERICA','0000442-21.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','0000622-87.2021.8.26.0602','','','','','','','','','','',''),
('SULAMERICA','0000676-10.2021.8.26.0002','','','','','','','','','','',''),
('SULAMERICA','0000766-70.2021.8.26.0114','','','','','','','','','','',''),
('SULAMERICA','0000798-20.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','0000806-97.2021.8.26.0002','','','','','','','','','','',''),
('SULAMERICA','0001050-26.2021.8.26.0002','','','','','','','','','','',''),
('SULAMERICA','0001368-06.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','0001474-65.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1000002-16.2021.8.26.0228','','','','','','','','','','',''),
('SULAMERICA','1000002-50.2021.8.26.0540','','','','','','','','','','',''),
('SULAMERICA','1000002-85.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000003-70.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000007-14.2021.8.26.0624','','','','','','','','','','',''),
('SULAMERICA','1000011-47.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000011-75.2021.8.26.0228','','','','','','','','','','',''),
('SULAMERICA','1000019-24.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000019-27.2021.8.26.0495','','','','','','','','','','',''),
('SULAMERICA','1000023-61.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000026-14.2021.8.26.0238','','','','','','','','','','',''),
('SULAMERICA','1000028-70.2021.8.26.0565','','','','','','','','','','',''),
('SULAMERICA','1000028-83.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000029-66.2021.8.26.0238','','','','','','','','','','',''),
('SULAMERICA','1000035-75.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000037-31.2021.8.26.0533','','','','','','','','','','',''),
('SULAMERICA','1000037-45.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000037-59.2021.8.26.0653','','','','','','','','','','',''),
('SULAMERICA','1000039-15.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000040-06.2021.8.26.0009','','','','','','','','','','',''),
('SULAMERICA','1000041-13.2021.8.26.0228','','','','','','','','','','',''),
('SULAMERICA','1000043-50.2021.8.26.0238','','','','','','','','','','',''),
('SULAMERICA','1000046-63.2021.8.26.0348','','','','','','','','','','',''),
('SULAMERICA','1000050-44.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000052-20.2021.8.26.0009','','','','','','','','','','',''),
('SULAMERICA','1000052-56.2021.8.26.0288','','','','','','','','','','',''),
('SULAMERICA','1000060-61.2021.8.26.0020','','','','','','','','','','',''),
('SULAMERICA','1000062-19.2021.8.26.0606','','','','','','','','','','',''),
('SULAMERICA','1000064-28.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000080-10.2021.8.26.0228','','','','','','','','','','',''),
('SULAMERICA','1000080-85.2021.8.26.0009','','','','','','','','','','',''),
('SULAMERICA','1000081-68.2021.8.26.0236','','','','','','','','','','',''),
('SULAMERICA','1000082-49.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000091-39.2021.8.26.0228','','','','','','','','','','',''),
('SULAMERICA','1000093-84.2021.8.26.0009','','','','','','','','','','',''),
('SULAMERICA','1000097-07.2021.8.26.0047','','','','','','','','','','',''),
('SULAMERICA','1000097-80.2021.8.26.0637','','','','','','','','','','',''),
('SULAMERICA','1000100-52.2021.8.26.0405','','','','','','','','','','',''),
('SULAMERICA','1000101-83.2021.8.26.0228','','','','','','','','','','',''),
('SULAMERICA','1000104-93.2021.8.26.0048','','','','','','','','','','',''),
('SULAMERICA','1000113-12.2021.8.26.0224','','','','','','','','','','',''),
('SULAMERICA','1000121-73.2021.8.26.0002','','','','','','','','','','',''),
('SULAMERICA','1000122-31.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000123-36.2021.8.26.0457','','','','','','','','','','',''),
('SULAMERICA','1000129-43.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000132-75.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000136-43.2021.8.26.0228','','','','','','','','','','',''),
('SULAMERICA','1000137-48.2021.8.26.0577','','','','','','','','','','',''),
('SULAMERICA','1000139-95.2021.8.26.0228','','','','','','','','','','',''),
('SULAMERICA','1000144-89.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000153-51.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000168-20.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000174-57.2021.8.26.0292','','','','','','','','','','',''),
('SULAMERICA','1000175-82.2021.8.26.0020','','','','','','','','','','',''),
('SULAMERICA','1000182-04.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000204-62.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000213-44.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000215-73.2021.8.26.0114','','','','','','','','','','',''),
('SULAMERICA','1000215-91.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000219-31.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000220-16.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000223-68.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000233-39.2021.8.26.0003','','','','','','','','','','',''),
('SULAMERICA','1000235-09.2021.8.26.0003','','','','','','','','','','',''),
('SULAMERICA','1000235-15.2021.8.26.0001','','','','','','','','','','',''),
('SULAMERICA','1000235-82.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000247-19.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000250-81.2021.8.26.0001','','','','','','','','','','',''),
('SULAMERICA','1000258-28.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000263-50.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000272-12.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000276-49.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000277-58.2021.8.26.0003','','','','','','','','','','',''),
('SULAMERICA','1000285-87.2021.8.26.0309','','','','','','','','','','',''),
('SULAMERICA','1000288-53.2021.8.26.0564','','','','','','','','','','',''),
('SULAMERICA','1000294-60.2021.8.26.0564','','','','','','','','','','',''),
('SULAMERICA','1000295-55.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000301-82.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000305-02.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000310-24.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000310-72.2021.8.26.0577','','','','','','','','','','',''),
('SULAMERICA','1000314-61.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000320-68.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000323-13.2021.8.26.0564','','','','','','','','','','',''),
('SULAMERICA','1000328-45.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000331-21.2021.8.26.0004','','','','','','','','','','',''),
('SULAMERICA','1000331-97.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000333-91.2021.8.26.0003','','','','','','','','','','',''),
('SULAMERICA','1000335-86.2021.8.26.0609','','','','','','','','','','',''),
('SULAMERICA','1000344-23.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1000352-58.2021.8.26.0016','','','','','','','','','','',''),
('SULAMERICA','1000352-73.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000354-73.2021.8.26.0001','','','','','','','','','','',''),
('SULAMERICA','1000358-80.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000361-50.2021.8.26.0006','','','','','','','','','','',''),
('SULAMERICA','1000366-57.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000370-27.2021.8.26.0001','','','','','','','','','','',''),
('SULAMERICA','1000371-61.2021.8.26.0405','','','','','','','','','','',''),
('SULAMERICA','1000371-79.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000379-56.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000408-88.2021.8.26.0114','','','','','','','','','','',''),
('SULAMERICA','1000408-91.2021.8.26.0016','','','','','','','','','','',''),
('SULAMERICA','1000424-47.2021.8.26.0565','','','','','','','','','','',''),
('SULAMERICA','1000426-51.2021.8.26.0004','','','','','','','','','','',''),
('SULAMERICA','1000432-67.2021.8.26.0001','','','','','','','','','','',''),
('SULAMERICA','1000439-19.2021.8.26.0564','','','','','','','','','','',''),
('SULAMERICA','1000454-22.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1000462-23.2021.8.26.0577','','','','','','','','','','',''),
('SULAMERICA','1000462-72.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000470-49.2021.8.26.0011','','','','','','','','','','',''),
('SULAMERICA','1000474-23.2021.8.26.0032','','','','','','','','','','',''),
('SULAMERICA','1000483-68.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000487-75.2021.8.26.0564','','','','','','','','','','',''),
('SULAMERICA','1000499-26.2021.8.26.0003','','','','','','','','','','',''),
('SULAMERICA','1000504-48.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1000508-81.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000515-73.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000531-27.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000541-69.2021.8.26.0005','','','','','','','','','','',''),
('SULAMERICA','1000567-73.2021.8.26.0003','','','','','','','','','','',''),
('SULAMERICA','1000577-16.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000578-98.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000584-08.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000595-47.2021.8.26.0001','','','','','','','','','','',''),
('SULAMERICA','1000599-44.2021.8.26.0564','','','','','','','','','','',''),
('SULAMERICA','1000600-40.2021.8.26.0625','','','','','','','','','','',''),
('SULAMERICA','1000608-17.2021.8.26.0625','','','','','','','','','','',''),
('SULAMERICA','1000626-85.2021.8.26.0577','','','','','','','','','','',''),
('SULAMERICA','1000661-27.2021.8.26.0001','','','','','','','','','','',''),
('SULAMERICA','1000679-42.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1000692-65.2021.8.26.0577','','','','','','','','','','',''),
('SULAMERICA','1000807-28.2021.8.26.0564','','','','','','','','','','',''),
('SULAMERICA','1000854-39.2021.8.26.0002','','','','','','','','','','',''),
('SULAMERICA','1000855-24.2021.8.26.0002','','','','','','','','','','',''),
('SULAMERICA','1000893-29.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000900-21.2021.8.26.0554','','','','','','','','','','',''),
('SULAMERICA','1000924-69.2021.8.26.0224','','','','','','','','','','',''),
('SULAMERICA','1000949-66.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1000970-58.2021.8.26.0224','','','','','','','','','','',''),
('SULAMERICA','1000980-86.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1001093-40.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1001106-85.2021.8.26.0602','','','','','','','','','','',''),
('SULAMERICA','1001186-03.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1001316-93.2021.8.26.0002','','','','','','','','','','',''),
('SULAMERICA','1001339-63.2021.8.26.0576','','','','','','','','','','',''),
('SULAMERICA','1001491-84.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1001515-61.2021.8.26.0602','','','','','','','','','','',''),
('SULAMERICA','1001632-09.2021.8.26.0002','','','','','','','','','','',''),
('SULAMERICA','1001894-53.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1002031-38.2021.8.26.0002','','','','','','','','','','',''),
('SULAMERICA','1002380-38.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1002667-04.2021.8.26.0002','','','','','','','','','','',''),
('SULAMERICA','1002800-43.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1003249-98.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1003553-97.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1003971-35.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1003981-79.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1004237-22.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1004331-67.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','1005293-90.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','0001774-27.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','0001891-18.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','0001907-69.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','0001933-67.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','0001991-70.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','0002058-35.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','0002065-27.2021.8.26.0100','','','','','','','','','','',''),
('SULAMERICA','0002190-38.2021.8.26.0021','','','','','','','','','','',''),
('SULAMERICA','1000060-29.2021.8.26.0063','','','','','','','','','','',''),
('SULAMERICA','1000253-15.2021.8.26.0008','','','','','','','','','','',''),
('SULAMERICA','1000261-89.2021.8.26.0008','','','','','','','','','','',''),
('SULAMERICA','1000525-09.2021.8.26.0008','','','','','','','','','','',''),
('SULAMERICA','1001689-40.2021.8.26.0224','','','','','','','','','','',''),
('SULAMERICA','1001882-32.2021.8.26.0361','','','','','','','','','','',''),
('TIM','0000001-69.2021.5.05.0006','','','','','','','','','','',''),
('TIM','0000005-09.2021.5.05.0006','','','','','','','','','','',''),
('TIM','0000006-63.2021.8.26.0004','','','','','','','','','','',''),
('TIM','0000009-68.2021.5.09.0965','','','','','','','','','','',''),
('TIM','0000010-14.2021.5.08.0017','','','','','','','','','','',''),
('TIM','0000017-71.2021.8.26.0011','','','','','','','','','','',''),
('TIM','0000018-97.2021.5.08.0014','','','','','','','','','','',''),
('TIM','0000023-22.2021.5.09.0005','','','','','','','','','','',''),
('TIM','0000025-70.2021.8.26.0424','','','','','','','','','','',''),
('TIM','0000027-78.2021.8.26.0282','','','','','','','','','','',''),
('TIM','0000030-25.2021.8.26.0511','','','','','','','','','','',''),
('TIM','0000031-10.2021.8.26.0511','','','','','','','','','','',''),
('TIM','0000033-51.2021.8.26.0358','','','','','','','','','','',''),
('TIM','0000034-82.2021.8.26.0278','','','','','','','','','','',''),
('TIM','0000043-62.2021.5.06.0145','','','','','','','','','','',''),
('TIM','0000045-57.2021.8.26.0005','','','','','','','','','','',''),
('TIM','0000063-36.2021.8.26.0019','','','','','','','','','','',''),
('TIM','0000075-49.2021.8.26.0278','','','','','','','','','','',''),
('TIM','0000102-08.2021.8.26.0189','','','','','','','','','','',''),
('TIM','0000123-54.2021.8.26.0004','','','','','','','','','','',''),
('TIM','0000133-42.2021.8.26.0152','','','','','','','','','','',''),
('TIM','0000142-79.2021.8.26.0127','','','','','','','','','','',''),
('TIM','0000146-81.2021.8.26.0462','','','','','','','','','','',''),
('TIM','0000155-68.2021.8.26.0001','','','','','','','','','','',''),
('TIM','0000156-90.2021.8.26.0021','','','','','','','','','','',''),
('TIM','0000160-33.2021.8.26.0020','','','','','','','','','','',''),
('TIM','0000195-02.2021.8.26.0114','','','','','','','','','','',''),
('TIM','0000205-73.2021.8.26.0590','','','','','','','','','','',''),
('TIM','0000214-35.2021.8.26.0008','','','','','','','','','','',''),
('TIM','0000250-38.2021.8.26.0021','','','','','','','','','','',''),
('TIM','0000251-83.2021.8.26.0001','','','','','','','','','','',''),
('TIM','0000265-55.2021.8.26.0005','','','','','','','','','','',''),
('TIM','0000283-43.2021.8.26.0016','','','','','','','','','','',''),
('TIM','0000288-07.2021.8.26.0003','','','','','','','','','','',''),
('TIM','0000295-96.2021.8.26.0003','','','','','','','','','','',''),
('TIM','0000320-67.2021.8.26.0405','','','','','','','','','','',''),
('TIM','0000337-11.2021.8.26.0565','','','','','','','','','','',''),
('TIM','0000348-96.2021.8.26.0320','','','','','','','','','','',''),
('TIM','0000366-53.2021.8.26.0309','','','','','','','','','','',''),
('TIM','0000416-27.2021.8.26.0003','','','','','','','','','','',''),
('TIM','0000418-82.2021.8.26.0007','','','','','','','','','','',''),
('TIM','0000478-91.2021.8.26.0577','','','','','','','','','','',''),
('TIM','0000543-20.2021.8.26.0405','','','','','','','','','','',''),
('TIM','0000551-42.2021.8.26.0002','','','','','','','','','','',''),
('TIM','0000586-42.2021.8.26.0021','','','','','','','','','','',''),
('TIM','0000758-81.2021.8.26.0021','','','','','','','','','','',''),
('TIM','0000771-80.2021.8.26.0506','','','','','','','','','','',''),
('TIM','0000931-65.2021.8.26.0002','','','','','','','','','','',''),
('TIM','0001014-08.2021.8.26.0576','','','','','','','','','','',''),
('TIM','0010001-96.2021.5.03.0067','','','','','','','','','','',''),
('TIM','0010003-28.2021.5.03.0112','','','','','','','','','','',''),
('TIM','0010006-83.2021.5.03.0014','','','','','','','','','','',''),
('TIM','0010008-83.2021.5.03.0004','','','','','','','','','','',''),
('TIM','0010016-42.2021.5.03.0107','','','','','','','','','','',''),
('TIM','0010020-83.2021.5.03.0138','','','','','','','','','','',''),
('TIM','0010020-86.2021.5.03.0137','','','','','','','','','','',''),
('TIM','0010021-42.2021.5.03.0179','','','','','','','','','','',''),
('TIM','0010022-61.2021.5.03.0006','','','','','','','','','','',''),
('TIM','0010023-12.2021.5.03.0082','','','','','','','','','','',''),
('TIM','0010026-10.2021.5.03.0100','','','','','','','','','','',''),
('TIM','0010039-68.2021.5.03.0145','','','','','','','','','','',''),
('TIM','0010046-98.2021.5.03.0100','','','','','','','','','','',''),
('TIM','0010051-82.2021.5.03.0145','','','','','','','','','','',''),
('TIM','0010055-60.2021.5.03.0100','','','','','','','','','','',''),
('TIM','0010064-81.2021.5.03.0145','','','','','','','','','','',''),
('TIM','0020007-58.2021.5.04.0028','','','','','','','','','','',''),
('TIM','0020018-62.2021.5.04.0101','','','','','','','','','','',''),
('TIM','0020024-35.2021.5.04.0662','','','','','','','','','','',''),
('TIM','0020025-20.2021.5.04.0662','','','','','','','','','','',''),
('TIM','0020026-05.2021.5.04.0662','','','','','','','','','','',''),
('TIM','0020027-46.2021.5.04.0029','','','','','','','','','','',''),
('TIM','1000001-82.2021.5.02.0605','','','','','','','','','','',''),
('TIM','1000002-30.2021.5.02.0391','','','','','','','','','','',''),
('TIM','1000002-76.2021.5.02.0602','','','','','','','','','','',''),
('TIM','1000003-10.2021.5.02.0716','','','','','','','','','','',''),
('TIM','1000003-15.2021.5.02.0391','','','','','','','','','','',''),
('TIM','1000003-34.2021.5.02.0611','','','','','','','','','','',''),
('TIM','1000005-04.2021.5.02.0611','','','','','','','','','','',''),
('TIM','1000005-64.2021.8.26.0294','','','','','','','','','','',''),
('TIM','1000005-69.2021.8.26.0066','','','','','','','','','','',''),
('TIM','1000006-24.2021.5.02.0373','','','','','','','','','','',''),
('TIM','1000010-17.2021.5.02.0323','','','','','','','','','','',''),
('TIM','1000010-44.2021.5.02.0605','','','','','','','','','','',''),
('TIM','1000010-67.2021.8.26.0268','','','','','','','','','','',''),
('TIM','1000010-83.2021.8.26.0004','','','','','','','','','','',''),
('TIM','1000011-23.2021.5.02.0607','','','','','','','','','','',''),
('TIM','1000011-35.2021.5.02.0603','','','','','','','','','','',''),
('TIM','1000012-02.2021.5.02.0609','','','','','','','','','','',''),
('TIM','1000013-07.2021.8.26.0564','','','','','','','','','','',''),
('TIM','1000013-46.2021.5.02.0072','','','','','','','','','','',''),
('TIM','1000014-41.2021.8.26.0483','','','','','','','','','','',''),
('TIM','1000014-45.2021.5.02.0035','','','','','','','','','','',''),
('TIM','1000015-26.2021.8.26.0483','','','','','','','','','','',''),
('TIM','1000017-07.2021.8.26.0059','','','','','','','','','','',''),
('TIM','1000018-33.2021.5.02.0601','','','','','','','','','','',''),
('TIM','1000018-94.2021.8.26.0219','','','','','','','','','','',''),
('TIM','1000018-98.2021.8.26.0638','','','','','','','','','','',''),
('TIM','1000019-22.2021.8.26.0529','','','','','','','','','','',''),
('TIM','1000019-64.2021.8.26.0030','','','','','','','','','','',''),
('TIM','1000020-12.2021.5.02.0016','','','','','','','','','','',''),
('TIM','1000020-51.2021.5.02.0391','','','','','','','','','','',''),
('TIM','1000023-07.2021.8.26.0417','','','','','','','','','','',''),
('TIM','1000023-22.2021.5.02.0030','','','','','','','','','','',''),
('TIM','1000025-04.2021.5.02.0705','','','','','','','','','','',''),
('TIM','1000026-34.2021.8.26.0005','','','','','','','','','','',''),
('TIM','1000027-76.2021.5.02.0089','','','','','','','','','','',''),
('TIM','1000028-70.2021.8.26.0177','','','','','','','','','','',''),
('TIM','1000029-24.2021.5.02.0064','','','','','','','','','','',''),
('TIM','1000029-71.2021.8.26.0495','','','','','','','','','','',''),
('TIM','1000030-34.2021.8.26.0664','','','','','','','','','','',''),
('TIM','1000031-11.2021.5.02.0705','','','','','','','','','','',''),
('TIM','1000031-90.2021.5.02.0711','','','','','','','','','','',''),
('TIM','1000032-48.2021.8.26.0229','','','','','','','','','','',''),
('TIM','1000035-20.2021.5.02.0391','','','','','','','','','','',''),
('TIM','1000036-66.2021.8.26.0009','','','','','','','','','','',''),
('TIM','1000037-18.2021.5.02.0026','','','','','','','','','','',''),
('TIM','1000038-39.2021.8.26.0396','','','','','','','','','','',''),
('TIM','1000039-28.2021.5.02.0045','','','','','','','','','','',''),
('TIM','1000039-57.2021.5.02.0391','','','','','','','','','','',''),
('TIM','1000040-64.2021.5.02.0610','','','','','','','','','','',''),
('TIM','1000041-67.2021.5.02.0604','','','','','','','','','','',''),
('TIM','1000042-82.2021.8.26.0588','','','','','','','','','','',''),
('TIM','1000043-36.2021.5.02.0087','','','','','','','','','','',''),
('TIM','1000044-71.2021.5.02.0717','','','','','','','','','','',''),
('TIM','1000045-04.2021.8.26.0405','','','','','','','','','','',''),
('TIM','1000045-64.2021.8.26.0191','','','','','','','','','','',''),
('TIM','1000046-88.2021.5.02.0087','','','','','','','','','','',''),
('TIM','1000049-04.2021.5.02.0391','','','','','','','','','','',''),
('TIM','1000049-70.2021.8.26.0266','','','','','','','','','','',''),
('TIM','1000050-40.2021.8.26.0562','','','','','','','','','','',''),
('TIM','1000053-40.2021.5.02.0068','','','','','','','','','','',''),
('TIM','1000053-78.2021.8.26.0405','','','','','','','','','','',''),
('TIM','1000054-69.2021.5.02.0603','','','','','','','','','','',''),
('TIM','1000054-75.2021.5.02.0601','','','','','','','','','','',''),
('TIM','1000054-80.2021.8.26.0464','','','','','','','','','','',''),
('TIM','1000059-16.2021.8.26.0428','','','','','','','','','','',''),
('TIM','1000069-85.2021.8.26.0161','','','','','','','','','','',''),
('TIM','1000072-54.2021.8.26.0415','','','','','','','','','','',''),
('TIM','1000073-83.2021.8.26.0562','','','','','','','','','','',''),
('TIM','1000076-84.2021.8.26.0482','','','','','','','','','','',''),
('TIM','1000082-07.2021.8.26.0704','','','','','','','','','','',''),
('TIM','1000095-23.2021.8.26.0278','','','','','','','','','','',''),
('TIM','1000108-43.2021.8.26.0659','','','','','','','','','','',''),
('TIM','1000108-70.2021.8.26.0068','','','','','','','','','','',''),
('TIM','1000112-26.2021.8.26.0483','','','','','','','','','','',''),
('TIM','1000116-50.2021.8.26.0358','','','','','','','','','','',''),
('TIM','1000116-53.2021.8.26.0066','','','','','','','','','','',''),
('TIM','1000125-48.2021.8.26.0152','','','','','','','','','','',''),
('TIM','1000129-72.2021.8.26.0318','','','','','','','','','','',''),
('TIM','1000131-96.2021.8.26.0009','','','','','','','','','','',''),
('TIM','1000144-34.2021.8.26.0191','','','','','','','','','','',''),
('TIM','1000149-18.2021.8.26.0624','','','','','','','','','','',''),
('TIM','1000163-38.2021.8.26.0224','','','','','','','','','','',''),
('TIM','1000175-74.2021.8.26.0637','','','','','','','','','','',''),
('TIM','1000189-95.2021.8.26.0269','','','','','','','','','','',''),
('TIM','1000225-78.2021.8.26.0127','','','','','','','','','','',''),
('TIM','1000236-73.2021.8.26.0009','','','','','','','','','','',''),
('TIM','1000257-25.2021.8.26.0405','','','','','','','','','','',''),
('TIM','1000268-62.2021.8.26.0564','','','','','','','','','','',''),
('TIM','1000270-97.2021.8.26.0704','','','','','','','','','','',''),
('TIM','1000277-74.2021.8.26.0127','','','','','','','','','','',''),
('TIM','1000286-53.2021.8.26.0477','','','','','','','','','','',''),
('TIM','1000295-85.2021.8.26.0001','','','','','','','','','','',''),
('TIM','1000296-95.2021.8.26.0704','','','','','','','','','','',''),
('TIM','1000306-02.2021.8.26.0006','','','','','','','','','','',''),
('TIM','1000324-35.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1000336-52.2021.8.26.0292','','','','','','','','','','',''),
('TIM','1000349-45.2021.8.26.0100','','','','','','','','','','',''),
('TIM','1000359-92.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1000362-32.2021.8.26.0007','','','','','','','','','','',''),
('TIM','1000363-05.2021.8.26.0302','','','','','','','','','','',''),
('TIM','1000371-33.2021.8.26.0576','','','','','','','','','','',''),
('TIM','1000378-56.2021.8.26.0016','','','','','','','','','','',''),
('TIM','1000380-89.2021.8.26.0577','','','','','','','','','','',''),
('TIM','1000390-15.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1000391-55.2021.8.26.0016','','','','','','','','','','',''),
('TIM','1000397-62.2021.8.26.0016','','','','','','','','','','',''),
('TIM','1000398-47.2021.8.26.0016','','','','','','','','','','',''),
('TIM','1000399-32.2021.8.26.0016','','','','','','','','','','',''),
('TIM','1000400-17.2021.8.26.0016','','','','','','','','','','',''),
('TIM','1000401-02.2021.8.26.0016','','','','','','','','','','',''),
('TIM','1000401-46.2021.8.26.0066','','','','','','','','','','',''),
('TIM','1000406-24.2021.8.26.0016','','','','','','','','','','',''),
('TIM','1000407-77.2021.8.26.0543','','','','','','','','','','',''),
('TIM','1000411-96.2021.8.26.0161','','','','','','','','','','',''),
('TIM','1000425-66.2021.8.26.0004','','','','','','','','','','',''),
('TIM','1000435-74.2021.8.26.0016','','','','','','','','','','',''),
('TIM','1000440-87.2021.8.26.0019','','','','','','','','','','',''),
('TIM','1000483-75.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1000497-44.2021.8.26.0007','','','','','','','','','','',''),
('TIM','1000498-29.2021.8.26.0007','','','','','','','','','','',''),
('TIM','1000510-16.2021.8.26.0016','','','','','','','','','','',''),
('TIM','1000516-57.2021.8.26.0037','','','','','','','','','','',''),
('TIM','1000565-09.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1000580-75.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1000649-62.2021.8.26.0114','','','','','','','','','','',''),
('TIM','1000691-52.2021.8.26.0554','','','','','','','','','','',''),
('TIM','1000816-70.2021.8.26.0602','','','','','','','','','','',''),
('TIM','1000862-82.2021.8.26.0562','','','','','','','','','','',''),
('TIM','1000931-88.2021.8.26.0506','','','','','','','','','','',''),
('TIM','1001140-69.2021.8.26.0114','','','','','','','','','','',''),
('TIM','1001177-68.2021.8.26.0576','','','','','','','','','','',''),
('TIM','1001285-73.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1001340-48.2021.8.26.0576','','','','','','','','','','',''),
('TIM','1001393-05.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1001508-26.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1001598-34.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1001630-79.2021.8.26.0506','','','','','','','','','','',''),
('TIM','1001726-09.2021.8.26.0114','','','','','','','','','','',''),
('TIM','1001853-89.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1001907-55.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1001922-24.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1001943-24.2021.8.26.0576','','','','','','','','','','',''),
('TIM','1002383-93.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1002479-11.2021.8.26.0002','','','','','','','','','','',''),
('TIM','1002620-27.2021.8.26.0100','','','','','','','','','','',''),
('TIM','1500326-20.2021.8.26.0075','','','','','','','','','','',''),
('TIM','1500526-44.2021.8.26.0037','','','','','','','','','','',''),
('TIM','1501631-39.2021.8.26.0075','','','','','','','','','','',''),
('TIM','0000030-78.2021.8.26.0655','','','','','','','','','','',''),
('TIM','0010006-95.2021.5.03.0010','','','','','','','','','','',''),
('TIM','1000243-68.2021.8.26.0008','','','','','','','','','','',''),
('TIM','1000296-49.2021.8.26.0008','','','','','','','','','','',''),
('TIM','1000609-15.2021.8.26.0071','','','','','','','','','','',''),
('TIM','1001076-91.2021.8.26.0071','','','','','','','','','','',''),
('TIM','1003958-36.2021.8.26.0100','','','','','','','','','','','')

select *
  from #analiseTimSulAmerica ats
WITH CTE_AnaliseTIMSul (Numero, NumeroEncontrado, IdTribunalJustica, StatusProcesso, 
                        DescrStatusProcesso, StatusCaptura, DescrStatusCaptura, IdProcesso, 
						Nome, Qualificacao, NomeAdvogado, Expressao) AS
  (SELECT ats.Numero,
          p.Numero,
          p.IdTribunalJustica,
          p.IdStatus,
          sp.Descricao,
          sc.IdStatus,
          ssc.Descricao,
          pp.IdProcesso,
          pp.Nome,
          pp.Qualificacao,
          pa.Nome,
          ttp.Expressao
   FROM #analiseTimSulAmerica AS ats
   LEFT JOIN Processo p ON p.Numero = ats.Numero COLLATE Latin1_General_CI_AS
   LEFT JOIN ProcessoParte pp ON pp.IdProcesso = p.id
   LEFT JOIN ProcessoParteAdvogado ppa ON ppa.IdProcessoParte = pp.Id
   LEFT JOIN ProcessoAdvogado pa ON pa.Id = ppa.IdProcessoAdvogado
   LEFT JOIN TermoTribunalProcesso ttp ON ttp.Numero = p.Numero
   LEFT JOIN StatusProcesso sp ON sp.Id = p.IdStatus
   LEFT JOIN SolicitacaoCaptura sc ON sc.Id = p.IdSolicitacaoCaptura
   LEFT JOIN StatusSolicitacaoCaptura ssc ON ssc.Id = sc.IdStatus)
UPDATE #analiseTimSulAmerica
SET NumeroEncontrado = ctea.Numero,
    IdTribunalJustica = ctea.IdTribunalJustica,
    DescrStatusProcesso = ctea.DescrStatusProcesso,
    StatusProcesso = ctea.StatusProcesso,
    DescrStatusCaptura = ctea.DescrStatusCaptura,
    Nome = ctea.Nome,
    Qualificacao = ctea.Qualificacao,
    NomeAdvogado = ctea.NomeAdvogado,
    Expressao = ctea.Expressao,
    StatusCaptura = ctea.StatusCaptura,
    IdProcesso = ctea.IdProcesso
FROM #analiseTimSulAmerica ats
JOIN CTE_AnaliseTIMSul AS ctea ON ctea.Numero = ats.Numero

---- CTE com selecao no nome


WITH CTE_AnaliseTIMSul (Numero, NumeroEncontrado, IdTribunalJustica, StatusProcesso, 
                        DescrStatusProcesso, StatusCaptura, DescrStatusCaptura, IdProcesso, 
						Nome, Qualificacao, NomeAdvogado, Expressao) AS
  (SELECT ats.Numero,
          p.Numero,
          p.IdTribunalJustica,
          p.IdStatus,
          sp.Descricao,
          sc.IdStatus,
          ssc.Descricao,
          pp.IdProcesso,
          pp.Nome,
          pp.Qualificacao,
          pa.Nome,
          ttp.Expressao
   FROM #analiseTimSulAmerica AS ats
   LEFT JOIN Processo p ON p.Numero = ats.Numero COLLATE Latin1_General_CI_AS
   LEFT JOIN ProcessoParte pp ON pp.IdProcesso = p.id
   LEFT JOIN ProcessoParteAdvogado ppa ON ppa.IdProcessoParte = pp.Id
   LEFT JOIN ProcessoAdvogado pa ON pa.Id = ppa.IdProcessoAdvogado
   LEFT JOIN TermoTribunalProcesso ttp ON ttp.Numero = p.Numero
   LEFT JOIN StatusProcesso sp ON sp.Id = p.IdStatus
   LEFT JOIN SolicitacaoCaptura sc ON sc.Id = p.IdSolicitacaoCaptura
   LEFT JOIN StatusSolicitacaoCaptura ssc ON ssc.Id = sc.IdStatus
WHERE  upper(pp.Nome) LIKE 'TIM%' OR upper(pp.Nome) LIKE 'SUL%')
UPDATE #analiseTimSulAmerica
SET NumeroEncontrado = ctea.Numero,
    IdTribunalJustica = ctea.IdTribunalJustica,
    DescrStatusProcesso = ctea.DescrStatusProcesso,
    StatusProcesso = ctea.StatusProcesso,
    DescrStatusCaptura = ctea.DescrStatusCaptura,
    Nome = ctea.Nome,
    Qualificacao = ctea.Qualificacao,
    NomeAdvogado = ctea.NomeAdvogado,
    Expressao = ctea.Expressao,
    StatusCaptura = ctea.StatusCaptura,
    IdProcesso = ctea.IdProcesso
FROM #analiseTimSulAmerica ats
JOIN CTE_AnaliseTIMSul AS ctea ON ctea.Numero = ats.Numero






