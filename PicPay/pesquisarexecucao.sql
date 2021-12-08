select sc.Descricao,
		pro.IdSolicitacaoCaptura, 
		pro.IdStatus, 
		count(1) as qutdade
  from processo pro
		,SolicitacaoCaptura sc
where pro.IdSolicitacaoCaptura in (8764,8866,8765,8867,8868,8840,8869,8870,8881,8882,8883)
and pro.IdSolicitacaoCaptura = sc.Id
and pro.IdStatus != 9
group by sc.Descricao, pro.IdSolicitacaoCaptura, pro.IdStatus
order by sc.Descricao,pro.IdSolicitacaoCaptura, pro.IdStatus


--update processo
--   set IdStatus = 1 , Inconsistencia = null, PossuiDocumento = 0, IdEquipamentoProcessamento = null
--where IdStatus = 4
--and IdSolicitacaoCaptura in (8764,8866,8765,8867,8868,8840,8869,8870)

--select * from processo where IdSolicitacaoCaptura = 8840

--update processo
--   set IdStatus = 1, Inconsistencia = null
--where IdSolicitacaoCaptura in (8764,8866,8765,8867,8868,8840,8869,8870)
--and IdStatus = 4


--update EquipamentoProcessamento
--   set Address = ''
--where id = 39

/*

delete ProcessamentoCaptura
where IdEquipamentoProcessamento = 39
and DataTermino is null

*/

--set rowcount  22

--update processo
--   set IdSolicitacaoCaptura = 8868
--where IdSolicitacaoCaptura = 8765


--set rowcount  0