ProcessamentoCaptura !!!

delete from ProcessamentoCaptura where idEquipamentoProcessamento = 26 and DataTermino is null



select pc.IdSolicitacaoCaptura, 
       CAST(pc.DataTermino AS DATE),
	   p.Numero,
	   p.Distribuicao,
	   p.IdEquipamentoProcessamento,
	   p.IdTribunalJustica
  from ProcessamentoCaptura pc 
  join Processo p on p.IdSolicitacaoCaptura = pc.IdSolicitacaoCaptura
  where CAST(pc.DataTermino AS DATE) = '2021-04-02'
--  where CAST(pc.DataTermino AS DATE) BETWEEN '2021-04-02' AND CAST(pc.DataTermino AS DATE) = '2021-04-02'
group by pc.IdSolicitacaoCaptura, CAST(pc.DataTermino AS DATE), p.Numero, p.Distribuicao, p.IdEquipamentoProcessamento, p.IdTribunalJustica
order by IdSolicitacaoCaptura


----para conferir acompanhamento

select ttp.id, 
       ttp.CriadoEm ,
       ttp.NomeParte, 
	   p.Numero, 
	   p.IdStatus, 
	   p.Forum
  from TermoTribunalProcesso ttp
  join Processo p on p.Numero = ttp.Numero
where cast(ttp.CriadoEm AS DATE) >= '2021-06-09' and cast(ttp.CriadoEm AS DATE) <= '2021-06-10'
and p.IdEquipamentoProcessamento = 36 
order by CAST(ttp.CriadoEm as date) desc








--WHERE dop.CriadoEm BETWEEN '20210216 00:00' AND '20210216 23:59:59'


select pc.IdSolicitacaoCaptura, 
       CAST(pc.DataTermino AS DATE),
	   p.Numero,
	   p.Distribuicao,
	   p.IdEquipamentoProcessamento,
	   p.IdTribunalJustica
  from ProcessamentoCaptura pc 
  join Processo p on p.IdSolicitacaoCaptura = pc.IdSolicitacaoCaptura
  where CAST(pc.DataTermino AS DATE) = '2021-04-02'
  and p.IdEquipamentoProcessamento is not null
group by pc.IdSolicitacaoCaptura, CAST(pc.DataTermino AS DATE), p.Numero, p.Distribuicao, p.IdEquipamentoProcessamento, p.IdTribunalJustica
order by IdSolicitacaoCaptura


----// principal 

select pc.IdEquipamentoProcessamento, 
       cast(pc.DataInicio AS DATE) as DataCaptura,
	   count(Cast(pc.DataInicio AS DATE)) as TotalPorData
  from ProcessamentoCaptura pc
where cast(pc.DataInicio AS DATE) = '2021-04-12'
where cast(pc.DataInicio AS DATE) >= '2021-04-01' and cast(pc.DataInicio AS DATE) <= '2021-04-05'
group by pc.IdEquipamentoProcessamento, cast(pc.DataInicio AS DATE)
order by pc.IdEquipamentoProcessamento, cast(pc.DataInicio AS DATE)



select pro.id as idprocesso
		,ttp.Numero
		,pro.IdStatus as IdProcesso
		,pro.Distribuicao
		,ttp.CriadoEm
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 15) as Desmenbrado
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 5) as DisponibilizadoS3
		,(select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 21) as IntegradoOmnijus
		,pro.IdEquipamentoProcessamento
		,pro.PossuiDocumento
		,pro.IdSolicitacaoCaptura
		,pro.Area
		,pro.IdEquipamentoProcessamento
  from TermoTribunalProcesso ttp
		,Processo pro
where ttp.Numero = pro.Numero
and ttp.IdSolicitacaoCaptura = pro.IdSolicitacaoCaptura
and ttp.NomeParte like 'PIC%'
and ttp.CriadoEm >= '2021-09-01 00:00:00'
and (select count(1) from HistoricoStatusProcesso hsp where hsp.idprocesso = pro.Id and hsp.IdStatus = 21) = 0
order by ttp.CriadoEm desc


























