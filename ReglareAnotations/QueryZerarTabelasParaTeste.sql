begin transaction

declare @idprocesso1 int 
declare @idprocesso2 int 
select @idprocesso1 = 37647  --> antes do Processo Chesf
select @idprocesso2 = 37647  --> Processo Chesf para teste 9643

declare @idsolicitacocaptura int 
select @idsolicitacocaptura = 761  --> Solicitacao captura Processo Chesf 

delete processoparteadvogado
	from processoparte pp
		,processo pro
where processoparteadvogado.IdProcessoParte = pp.id
  and pp.idprocesso = pro.id
  and pro.IdSolicitacaoCaptura = @idsolicitacocaptura
  and (pro.id >= @idprocesso1 and pro.id <= @idprocesso2)

delete processoAdvogado 
		from processo pro
where processoAdvogado.idprocesso = pro.id 
  and pro.IdSolicitacaoCaptura = @idsolicitacocaptura
  and (pro.id >= @idprocesso1 and pro.id <= @idprocesso2)

delete processoparte 
		from processo pro
where processoparte.idprocesso = pro.id 
  and pro.IdSolicitacaoCaptura = @idsolicitacocaptura
  and (pro.id >= @idprocesso1 and pro.id <= @idprocesso2)

update processo 
	set idstatus = 1 
		,idinstanciatribunal = null
		,vara = null
		,uf = null
		,assunto = null
		,distribuicao = null
		,valoracao = null
		,classe = null
  where IdSolicitacaoCaptura = @idsolicitacocaptura
  and (id >= @idprocesso1 and id <= @idprocesso2)


delete processomovimento 
   from processo pro
where pro.numero = processomovimento.numero 
  and pro.IdSolicitacaoCaptura = @idsolicitacocaptura
  and (pro.id >= @idprocesso1 and pro.id <= @idprocesso2)


delete termotribunalprocesso 
   from processo pro
where pro.numero = termotribunalprocesso.numero 
  and pro.IdSolicitacaoCaptura = @idsolicitacocaptura
  and (pro.id >= @idprocesso1 and pro.id <= @idprocesso2)

update SolicitacaoCaptura
   set idstatus = 9
where descricao like '%distr%'

update SolicitacaoCaptura
   set idstatus = 12
where id = @idsolicitacocaptura

commit transaction
--rollback transaction


--delete  from ProcessamentoCaptura where id = 12015

--select * from ProcessamentoCaptura where IdEquipamentoProcessamento = 26


