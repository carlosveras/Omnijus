----
admin
0mn1#Local 

---- para debugar com o site aberto
na linha de comando --> cmd
chrome.exe -remote-debugging-port=9014 --user-data-dir="D:\Selenium\Chrome_Test"

firefox.exe -start-debugger-server 9222

---- comandos git 
https://www.atlassian.com/br/git/tutorials/setting-up-a-repository

ver status git:
git status

ver as configuracoes do git na maquina local:
git config --list --show-origin

---- setar usuario e email global
configurar o usuario e email:
git config --global user.name "carlosveras"
git config --global user.email "carlos.veras@reglare.com.br"

---- setar usuario e email para cada repositorio
git config user.name "carlosveras"
git config user.email "carlos.veras@outlook.com"

para setar o repositorio remoto:
git remote set-url origin https://carlosveras@bitbucket.org/ragpmartins/capturadadosprocesso.git

para setar o repositorio local:
git init

para clonar o repositorio:
git clone https://carlosveras@bitbucket.org/ragpmartins/capturadadosprocesso.git

commitar alteracoes:
git commit -am "Exclusao pasta de armazenamento do processamento captura"

subir alteracoes para  a nuvem:
git push -u origin --all

para baixar a ultima versao da aplicacao
git pull

para visualizar os commits que nao subiu para o repositorio:
git log --branches --not --remotes

git diff --stat --cached origin/master

para chamar o meld no momento de fazer o merge das modificacoes 
deve-se alterar o arquivo .gitconfig que se encontra na pasta
c:\users\nomeuser com as linhas abaixo:

[diff]
	tool = meld
[difftool "meld"]
	path = C:/Program Files (x86)/Meld/Meld.exe
[difftool]
	prompt = false
	
executar o comando no git-bash

$git difftool origin/master

<---- comandos XPATH exemplos -->


com span e texto:
//span[@class='ng-star-inserted'][text()='50']

para inspecionar por href:
//a[text()='Compare']

para inspecionar por input:
//input[@type='text' and @name='email']

para inspecionar por id:
//div[@id='rc-imageselect']

//para inspecionar elementos filhos - no caso a 2 div  
//abaixo da class
//.[@class='primary-controls']/child::div[2]

//para inspecionar elementos seguintes no caso um input
//abaixo da class
//[@id="captcha"]/following::input

para inspecionar por href:
//a[text()='Compare']

para inspecionar por input:
//input[@type='text' and @name='email']

para inspecionar por id:
//div[@id='rc-imageselect']

com span e texto:
//span[@class='ng-star-inserted'][text()='50']

//para inspecionar elementos filhos - no caso a 2 div abaixo da class
//.[@class='primary-controls']/child::div[2]

//.[contains(text(),'A verificação de captcha não está correta.')]
//.[contains(text(),'Atendimento ao usuário do DEJT:')]
//input[@id='imgCaptcha']
//[@id="portalTabs__consultaUnificada"]/child::a[1]
div//table//tbody//tr//td[@class='modalTitulo']
//[@id="content100"]//h3[.="Erro"]
//div[@id='idOestePortal']
//.[@class='rc-imageselect-error-dynamic-more']
//span[@class='title']
//.[@class='modalTitulo']
//.[@class='esajCelulaConteudoServico']
//.[@class='rc-image-tile-33']
//.[@class='rc-imageselect-desc-no-canonical']/strong
//.[@class='rc-imageselect-desc']/strong
//.[@class='rich-messages-label']
//.[@id='corpo:formulario:dataFim']//following::button[1]
//select[@id='corpo:formulario:tribunal']//following::td[@class='celulaFormulario'][1]
//div[@id='diarioCon']//fieldset[@class='plc-fieldset']
//[@id="corpo:formulario:tribunal"]//following::td[@class='celulaFormulario']//span[@class='ico iNavProximo']
//[@id='diarioInferiorNav']/preceding::tbody[1]
//.[contains(text(),'A verificação de captcha não está correta.')]
//.[contains(text(),'Atendimento ao usuário do DEJT:')]
//.[@class='esajCelulaConteudoServico']
//.[@class='app-detalhes-processo.ng-tns-c115-5']
//.[@class='rc-image-tile-33']
//.[@class='rc-imageselect-desc-no-canonical']/strong
//.[@class='rc-imageselect-desc']/strong
//.[@class='rich-messages-label']
//[@id="captcha"]/following::input
//input[@id='imgCaptcha']
div//table//tbody//tr//td[@class='modalTitulo']
//.[@class='rc-imageselect-error-dynamic-more']
//span[@class='title']
//.[@class='modalTitulo']
//[@id="content100"]//h3[.="Erro"]
//.[@id='corpo:formulario:dataFim']//following::button[1]
//[@id="corpo:formulario:tribunal"]//following::td[@class='celulaFormulario']//span[@class='ico iNavProximo']
//[@id='diarioInferiorNav']/preceding::tbody[1]
//.[@id='senhaProvisoria']
//.[@id='motivo']
//.[@id='motivo']/following::button[1]
//select[@id='corpo:formulario:tribunal']//following::td[@class='celulaFormulario'][1]
//div[@id='diarioCon']//fieldset[@class='plc-fieldset']
//div[@id='idOestePortal']
//[@id="portalTabs__consultaUnificada"]/child::a[1]
//span[text()='Listar todos os personagens']
//a[text()='Listar todos os personagens']
//.[@id='lista-historico-personagens']/preceding::i[1]
//.[contains(text(),'Localização')]/following::div[1]
//.[contains(text(),'Réu')]/following::div[1]
//.[contains(text(),'Dados dos')]/following::div[2]
//.[contains(text(),'Dados dos')]/following::div[3]
//.[contains(text(),'Dados dos')]/following::div[5]
//.[contains(text(),'Dados dos')]/following::div[5]
//.[contains(text(),'Dados dos')]/following::div[4]
//.[contains(text(),'Dados dos')]/following::div[4]
//.[contains(text(),'Dados dos')]/following::div[2]
//.[contains(text(),'Dados dos')]/following::div[9] 
//.[contains(text(),'Para visualizar')]/following::div[1] 
//.[contains(text(),'específica')]
//.[contains(text(),'Dados do')]/following::div[2]
//.[contains(text(),'expand_more')]/following::div[contains(@class, 'mat-tree-node')]
//.[contains(@aria-label,'Salvar Cópia')]
//.[contains(text(),'O processo informado não foi encontrado')]
//.[contains(text(),'Processo Eletrônico - Novo')]
//.[@class='row box-conteudo box-rb ng-tns-c115-1 ng-star-inserted']
//.[app-detalhes-processo]/following::div/div/div[3]
/html/body/app-root/app-detalhes-processo/section/div/div/div[3]
//.[@class='row box-conteudo box-rb ng-tns-c115-5 ng-star-inserted']
//.[@role='alert']

---- MAQUINAS NOVAS REGLARE
Usuário: admomnijus
Senha: Kolim@050607

Usuário: omnijus.com.br\bot_reglare
Senha: Kolim@050607&$

25 -- 002248210BF9 -- 172.13.0.7 -- maquina testada -- erro captcha -- 24-03-2021
27 -- 000D3A8E1DAE -- 172.13.0.8 -- maquina testada -- erro captcha -- 24-03-2021
28 -- 000D3A99DE70 -- 172.13.0.9 -- maquina testada -- erro captcha -- 24-03-2021
29 -- 000D3A9B0473 -- 172.13.0.10 - maquina testada -- erro captcha -- 24-03-2021
30 -- 000D3A8A8326 -- 172.13.0.11 - maquina testada -- erro captcha -- 24-03-2021
31 -- 000D3A9E9470 -- 172.13.0.12 - maquina testada -- erro captcha -- 24-03-2021
32 -- 000D3A98AC56 -- 172.13.0.13 - maquina testada -- erro captcha -- 24-03-2021

33 -- 000D3A98A6F4 -- 172.13.0.14 - maquina testada -- erro captcha -- 24-03-2021

34 -- 000D3A8E1FD3 -- 172.13.0.15 - maquina testada -- erro captcha -- 24-03-2021

35 -- 000D3A99DA38 -- 172.13.0.16 - maquina testada -- erro captcha -- 24-03-2021

36 -- 000D3A8A4295 -- 172.13.0.17 - maquina testada -- erro captcha -- 24-03-2021
37 -- 000D3A10FE65 -- 172.13.0.18 - maquina testada -- erro captcha -- 24-03-2021


34 -- 172.13.0.15 


---- BANCO DE HOMOLOGACAO 

Host: reglare-hml.privatelink.database.windows.net
host: reglare-prd.privatelink.database.windows.net

Usuário: admomnijus
Senha: Captura909

---- BANCO DE PRODUCAO 

host: reglare-prd.privatelink.database.windows.net
User: admomnijus
Senha: Ag3xH%a5A8Oq!9Y

---- tabelas envolvidas no processo de desmembrar arquivo PDF

HistoricoStatusProcessoCopia
HistoricoStatusProcesso
ProcessoPeca
ProcessoMovimento
ProcessoCapturado

---- maquinas capturando processos
select pc.Id as idprocessamento
		,pc.IdEquipamentoProcessamento
		,pc.DataInicio
		,sc.Id as idsolicitacao
		,sc.DataUltimoProcessamento
		,sc.DataTerminoUltimaCaptura
		,sc.descricao
		,(select COUNT(1) from Processo pro where pro.idsolicitacaocaptura = sc.id and pro.idstatus = 2) as capturados
		,(select COUNT(1) from Processo pro where pro.idsolicitacaocaptura = sc.id and pro.idstatus = 10) as passados
		,(select COUNT(1) from Processo pro where pro.idsolicitacaocaptura = sc.id and pro.idstatus = 1) as passar
		,(select COUNT(1) from Processo pro where pro.idsolicitacaocaptura = sc.id and pro.idstatus = 7) as segredo
		,ep.Descricao
	from ProcessamentoCaptura pc
		,SolicitacaoCaptura sc
		,EquipamentoProcessamento ep
where pc.datatermino is null
and pc.idsolicitacaocaptura = sc.id
and pc.IdEquipamentoProcessamento = ep.Id
--and pc.IdEquipamentoProcessamento = 27
order by pc.IdEquipamentoProcessamento,pc.DataInicio

---- query's para levantamento por idsolicitacocaptura

 select * 
   from SolicitacaoCaptura sc
order by sc.DataUltimoProcessamento desc

select p.Numero, 
	   p.IdTribunalJustica,
	   p.IdStatus as 'StatusProcesso',  sp.Descricao as 'Descr. StatusProcesso', 
	   sc.IdStatus as 'Status Captura', ssc.Descricao as 'Descr. StatusCaptura', 
	   sc.DataUltimoProcessamento,
       pp.IdProcesso,
       pp.Nome, 
	   pp.Qualificacao, 
	   pa.id, 
	   pa.Nome as 'NomeAdvogado', 
       ttp.Expressao
 from Processo p
left join ProcessoParte pp on pp.IdProcesso = p.id
left join ProcessoParteAdvogado ppa on ppa.IdProcessoParte = pp.Id
left join ProcessoAdvogado pa on pa.Id = ppa.IdProcessoAdvogado
left join TermoTribunalProcesso ttp on ttp.Numero = p.Numero
join StatusProcesso sp on sp.Id = p.IdStatus
join SolicitacaoCaptura sc on sc.Id = p.IdSolicitacaoCaptura
join StatusSolicitacaoCaptura ssc on ssc.Id = sc.IdStatus
where p.IdSolicitacaoCaptura in (803,1251,1250,1240,809)
and ttp.expressao is not null

---- query's epecificas para conferencia gravacao tabelas do sistema

-- TERMOTRIBUNALPROCESSO -- processos especificos com base expressao regular
select ttp.CriadoEm,
       ttp.Numero,
	   ttp.NomeParte,
	   ttp.Expressao,
	   p.IdTribunalJustica,
	   p.IdTecnologiaSite,
	   p.OrgaoJulgador,
	   p.Forum,
	   p.Comarca,
	   p.Vara
  from TermoTribunalProcesso ttp
  join Processo p on p.Numero = ttp.Numero
 where p.IdTribunalJustica = 2 
order by ttp.criadoEm desc

-- PROCESSO -- processos
select p.id, 
       p.IdSolicitacaoCaptura, 
       p.Numero, 
	   p.IdTribunalJustica,
--	   p.IdStatus as 'StatusProcesso',  sp.Descricao as 'Descr. StatusProcesso', 
--	   sc.IdStatus as 'Status Captura', ssc.Descricao as 'Descr. StatusCaptura', 
--	   convert(CHAR,sc.DataTerminoUltimaCaptura,103) as 'DataTerminoUltimaCaptura',
--	   sc.CapturarDistribuicao,
	   p.IdEquipamentoProcessamento,
	   p.Comarca,
	   p.Vara,
	   p.Forum,
	   p.OrgaoJulgador, 
	   sc.CriadoEm
  from Processo p
  join StatusProcesso sp on sp.Id = p.IdStatus
  join SolicitacaoCaptura sc on sc.Id = p.IdSolicitacaoCaptura
  join StatusSolicitacaoCaptura ssc on ssc.Id = sc.IdStatus
where sc.CriadoEm >= '2020-10-21'

-- MOVIMENTOPROCESSO -- movimentacoes dos processos
select * 
  from processomovimento pm
 where pm.numero = '0010220-06.2020.8.16.0044'

-- PROCESSOPARTES -- partes e seus respectivos advogados
select pp.criadoEm,
       pp.id, 
       pp.IdProcesso, 
	   ppa.IdProcessoParte, 
       pp.Nome, 
	   pp.Qualificacao, 
	   pa.id, 
	   ppa.IdProcessoAdvogado, 
	   pa.Nome, 
	   pa.Qualificacao,
	   pa.OAB
  from ProcessoParte pp
  left join ProcessoParteAdvogado ppa on ppa.IdProcessoParte = pp.Id
  left join ProcessoAdvogado pa on pa.Id = ppa.IdProcessoAdvogado
where pp.IdProcesso in

-- PROCESSO COM PROCESSOPARTES

select p.Id,
       pp.IdProcesso,
	   ppa.IdProcessoParte, 
       pp.Nome, 
	   pp.Qualificacao, 
	   pa.id, 
	   ppa.IdProcessoAdvogado, 
	   pa.Nome, 
	   pa.Qualificacao,
	   pa.OAB
  from Processo p
left join ProcessoParte pp on pp.IdProcesso = p.id
left join ProcessoParteAdvogado ppa on ppa.IdProcessoParte = pp.Id
left join ProcessoAdvogado pa on pa.Id = ppa.IdProcessoAdvogado
where p.Numero = ('1000037-18.2021.5.02.0026')

-- HISTORICO DE STATUS DO PROCESSO

select * 
  from HistoricoStatusProcesso hsp
  join StatusProcesso sp on sp.Id = hsp.IdStatus
 where hsp.IdProcesso = 1889296
order by hsp.Id desc

---- fim query's epecificas para conferencia gravacao tabelas do sistema


<---- QUERY PARA ENCONTRAR MAIOR IDSTATUS POR GRUPO DE REGISTROS DENTRO DE UMA DATA --->

 WITH ranked_hsp AS (
  SELECT m.*,   ROW_NUMBER() OVER (PARTITION BY IdProcesso ORDER BY IdStatus DESC) AS rn
  FROM HistoricoStatusProcesso AS m where cast(m.Data AS DATE) = '2021-12-20'
)
SELECT ranked_hsp.IdProcesso, 
       ranked_hsp.Data, 
	   ranked_hsp.IdStatus, 
	   sp.Descricao, 
	   p.Numero 
  FROM ranked_hsp
  join StatusProcesso sp on sp.Id = ranked_hsp.IdStatus
  join Processo p on p.id = ranked_hsp.IdProcesso
 WHERE rn = 1; --<< escolher o rank 1,2,3 etc

---- query para pesquisar fase do processo por ultimo status

select pro.id 
      ,pro.Numero
      ,pro.Forum
	  ,pro.Vara
	  ,pro.OrgaoJulgador
	  ,hsp.IdStatus
	  ,sp.Descricao
	  ,cast(hsp.Data AS DATE) as CriadoEm
  from Processo pro
  join HistoricoStatusProcesso hsp on hsp.IdProcesso = pro.id 
  join StatusProcesso sp on sp.Id = hsp.IdStatus
where pro.Numero in
('0006436-90.2021.8.19.0209',
'5022937-13.2021.8.08.0024')
and hsp.IdStatus = 23
and cast(hsp.Data AS DATE) = '2021-12-16'
--order by 
--select * from StatusProcesso

---- query para contar processos capturados por data
select ttp.id, 
       CAST(ttp.CriadoEm as date) as CriadoEm,
       ttp.NomeParte, 
	   p.Numero, 
	   p.IdStatus, 
	   p.Forum
  from TermoTribunalProcesso ttp
  join Processo p on p.Numero = ttp.Numero
where cast(ttp.CriadoEm AS DATE) >= '2021-05-25' and cast(ttp.CriadoEm AS DATE) <= '2021-05-28'
and p.IdEquipamentoProcessamento = 36 
order by CAST(ttp.CriadoEm as date)

---- query para pesquisar somente campo com numeros e letras

naoaceito --- 1234590435 13.3434.2-234.3423 
aceito ------ n.234234 2342jafdf-234 

select *
  from DiarioOficialProcessos dop
WHERE dop.CriadoEm BETWEEN '20210216 00:00' AND '20210216 23:59:59'
AND (PATINDEX('%[a-zA-Z]%', dop.Numero) <> 0)

---- query termotribunalprocesso por data de criacao

select ttp.CriadoEm,
       p.IdTribunalJustica,
       ttp.NomeParte,
	   ttp.Expressao
  from TermoTribunalProcesso ttp
  join Processo p on p.Numero = ttp.Numero
WHERE ttp.CriadoEm BETWEEN '20210207 00:00' AND '20210207 23:59:59'
order by ttp.CriadoEm desc

---- desativa maquina para parar processamento

update EquipamentoProcessamento 
   set Ativo = 0 
where id = 26

---- ativa maquina para parar processamento

update EquipamentoProcessamento 
   set Ativo = 1 
where id = 26

---- query parametros maquina processamento
select ept.Id,
	   ept.IdEquipamentoProcessamento,
	   ept.Ativo,
       ept.IdTribunal,
	   ept.Sequencia,
	   ept.QuantidadeTask,
	   ept.IdTecnologiaSite,
	   ept.Sequencia,
	   ept.BaixarCopia,
	   ept.CapturarDistribuicao,
	   ept.CapturarDado,
	   ept.CapturarMovimento,
	   ept.CopiaDocumentoUnico
  from EquipamentoProcessamentoTribunal ept
 where IdEquipamentoProcessamento = 26
 
select epp.Id,
       epp.CriadoEm,
	   epp.Descricao,
	   epp.Valor
  from EquipamentoProcessamentoParametro epp
where epp.idEquipamentoProcessamento = 26

 select ep.Id,
        ep.Descricao,
		ep.Address,
		ep.QuantidadeTask
   from EquipamentoProcessamento ep
  where ep.id = 26 

---- query EQUIPAMENTO PARAMETROS
select ep.Id,
       ep.Descricao,
	   ep.Address,
	   ep.QuantidadeTask,
	   ep.Ativo,
	   epp.Descricao,
	   epp.Valor
  from EquipamentoProcessamento ep
  join EquipamentoProcessamentoParametro epp on epp.IdEquipamentoProcessamento = ep.Id
 where ep.Id = 26
 order by ep.Id

---- query pesquisa tabela TERMOTRIBUNALPROCESSO
select ttp.CriadoEm,
       ttp.Numero,
	   ttp.IdSolicitacaoCaptura,
	   ttp.NomeParte
  from TermoTribunalProcesso ttp
 where ttp.CriadoEm >= '2020-10-10'
order by ttp.criadoEm desc

---- query pega tabela alterada por update insert ou delete
SELECT name, 
	   convert(CHAR,[modify_date],103) as Data 
  FROM sys.tables
order by modify_date desc

---- query solicitacao por TRT
select pro.IdSolicitacaoCaptura
		,pro.numero
		,pro.Distribuicao
		,sc.IdStatus
  from SolicitacaoCaptura sc
		,Processo Pro
where sc.descricao like 'Captura Distribuição - TRT1 %'
and sc.id = Pro.IdSolicitacaoCaptura
and pro.numero = (select max(numero)
					from processo pro1
					where sc.id = pro1.IdSolicitacaoCaptura
					and pro1.IdStatus = 2)
order by 1 desc

---------------------------------------------------------------

---- QUERY PARA GERAR FAIXA DE NUMERACAO

--===================================================================================================
--Incluir a Faixa de Numerçao -- 0800072-78.2021.8.19.0206
--===================================================================================================
insert into ForumFaixaNumeroProcesso values (getdate(),1,null,null,3763,1,1,1,'0800000',5319,1,3)

select @@IDENTITY
--8628
--===================================================================================================

--===================================================================================================
--Incluir a Faixa de Numerçao no Ano
--===================================================================================================
insert into ForumFaixaNumeroAno values (getdate(),1,null,null,8628,2021,0800072)
--===================================================================================================

--===================================================================================================
--Incluir a Solicitação de Captura
--===================================================================================================
insert into SolicitacaoCaptura values
(getdate(),1,'Captura Distribuição - TJRJ - 0206 - 0800000',1,3,null,0,1,0,0,0,1,1,0,0,null,null,null)

select @@IDENTITY
--8864
--===================================================================================================
insert into Processo (IdSolicitacaoCaptura,Numero,IdTribunalJustica,IdStatus,Eletronico,IdTecnologiaSite,IdFaixaNumeroProcesso, IdInstanciaTribunal, justicagratuita)
values (8864,'9999999-00.2021.8.19.0206',2,1,1,20,8628, 5319, 0)
--===================================================================================================

---- query gerar novos PROCESSOS

select * from solicitacaocaptura
where Descricao like '%distr%TRT%'
and IdStatus != 9 ------> sempre verificar o status

update solicitacaocaptura
  set idstatus = 3 -----> sempre verificar o status
where id = 761


delete from ProcessamentoCaptura where idEquipamentoProcessamento in (26,31) and DataTermino is null


---- insert na solicitacaocaptura
insert into SolicitacaoCaptura values (GETDATE(),1,'Captura Distribuição - TJRJ - 0042 - 0800000',0,3,null,0,1,0,0,0,1,1,0,0,null,null,null)

--- primeiro campo refere-se ao id da solicitacaocaptura gerado no insert acima
insert into Processo values (8841,'9999999-00.2021.8.19.0042',2,null,1,1,null,5319,20,
null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,
5314,0,null,0,null)

---- query pegar HISTORICOS DAS SOLICITACOES CAPTURA
select hssc.Id, 
       hssc.IdSolicitacaoCaptura, convert(CHAR,hssc.Data,103) as Data, 
	   hssc.IdStatus, 
	   ssc.Descricao
  from HistoricoStatusSolicitacaoCaptura hssc
  join StatusSolicitacaoCaptura ssc on ssc.Id = hssc.IdStatus
 where IdSolicitacaoCaptura = 763
 order by hssc.Data desc


---- query para pegar os HISTORICOS DOS PROCESSOS COM OS STATUS
select hsp.id, hsp.IdProcesso, hsp.IdStatus, sp.Id, sp.Descricao 
  from HistoricoStatusProcesso hsp
  join StatusProcesso sp on sp.Id = hsp.IdStatus
 where IdProcesso in (37728, 38258)  

---- query para pegar equipamento tribunal usuario e senha

 select ept.Id,
       ept.IdEquipamentoProcessamento, 
	   it.id,
       it.IdTribunal,
       it.URL,
	   tj.Descricao,
	   tj.Sigla,
	   ept.Ativo,
       ep.Descricao,
	   ep.Ativo,
       tj.IdentificacaoProcesso,
	   ua.Usuario,
	   ua.PWD
  from EquipamentoProcessamentoTribunal ept 
  join TribunalJustica tj on tj.id = ept.IdTribunal
  join InstanciaTribunal it on it.IdTribunal = tj.Id
  join EquipamentoProcessamento ep on ep.Id = ept.IdEquipamentoProcessamento 
left  join UsuarioAcesso ua on ua.IdTribunal = tj.Id
---where idEquipamentoProcessamento = 26
where ept.Ativo = 1
order by ept.IdEquipamentoProcessamento

---- query para pegar os STATUS DOS PROCESSOS
select p.id, 
       p.IdSolicitacaoCaptura, 
       p.Numero, 
	   p.IdTribunalJustica,
	   p.IdStatus as 'StatusProcesso',  sp.Descricao as 'Descr. StatusProcesso', 
	   sc.IdStatus as 'Status Captura', ssc.Descricao as 'Descr. StatusCaptura', 
	   convert(CHAR,sc.DataTerminoUltimaCaptura,103) as 'DataTerminoUltimaCaptura',
	   sc.CapturarDistribuicao,
	   p.IdEquipamentoProcessamento
  from Processo p
  join StatusProcesso sp on sp.Id = p.IdStatus
  join SolicitacaoCaptura sc on sc.Id = p.IdSolicitacaoCaptura
  join StatusSolicitacaoCaptura ssc on ssc.Id = sc.IdStatus
where p.IdSolicitacaoCaptura = 761
and p.Numero =  '1000065-43.2020.5.02.0374'

---- query pesquisar INSTANCIA TRIBUNAL
  select it.IdTribunal,
         it.Descricao,
         it.URL,
		 tnw.Descricao,
		 ts.Descricao,
		 uf.Sigla
    from InstanciaTribunal it
    join TipoNavegadorWeb tnw on tnw.id = it.IdTipoNavegador
    join TecnologiaSite ts on ts.id = it.IdTecnologiaSite
	join TribunalJustica tj on tj.Id = it.IdTribunal 
    join Uf uf on uf.id = tj.IdUF


---- query pesquisar TRIBUNAL JUSTICA
select tj.Id, 
       tj.Descricao, 
	   tj.Sigla,
       tj.IdentificacaoProcesso,	   
	   uf.Nome, 
	   uf.Sigla, 
	   it.IdTecnologiaSite, 
	   ts.Descricao,
	   it.URL 
  from TribunalJustica tj
  join UF uf on uf.id = tj.IdUF
  join InstanciaTribunal it on it.IdTribunal = tj.Id
  join TecnologiaSite ts on ts.id = it.IdTecnologiaSite
order by id

---- query pesquisar tribunal de justica com tecnologia do site e url
select it.Id,
       it.Descricao,
       it.URL,
	   it.IdTecnologiaSite,
	   ts.Descricao,
	   tj.Descricao,
       tj.IdentificacaoProcesso	   
  from InstanciaTribunal it
  join TecnologiaSite ts on ts.Id = it.IdTecnologiaSite
  join TribunalJustica tj on tj.Id = it.IdTribunal
 order by it.IdTecnologiaSite

---- query para ativar desativar o pc para determinado tribunal
select ept.Id,
       ept.IdEquipamentoProcessamento, 
       ept.IdTribunal, 
       it.IdTribunal,
	   it.id,
	   tj.Descricao,
	   tj.Sigla,
	   ept.Ativo,
       tj.IdentificacaoProcesso	   
  from EquipamentoProcessamentoTribunal ept 
  join TribunalJustica tj on tj.id = ept.IdTribunal
  join InstanciaTribunal it on it.IdTribunal = tj.Id
where idEquipamentoProcessamento = 26

update EquipamentoProcessamentoTribunal
   set Ativo = 1 
where id =3223 -- tj 5022

update EquipamentoProcessamentoTribunal
   set Ativo = 0 
where id =3224 -- tj 2002

---- query para pegar as partes e seus advogados
select pp.id, 
       pp.IdProcesso, 
	   ppa.IdProcessoParte, 
       pp.Nome, 
	   pp.Qualificacao, 
	   pa.id, 
	   ppa.IdProcessoAdvogado, 
	   pa.Nome, 
	   pa.Qualificacao,
	   pa.OAB
  from ProcessoParte pp
  left join ProcessoParteAdvogado ppa on ppa.IdProcessoParte = pp.Id
  left join ProcessoAdvogado pa on pa.Id = ppa.IdProcessoAdvogado
where pp.IdProcesso in (96643)

--- query para pegar campo distribuicao sem hora:minuto

SELECT top 1000 p.Numero, p.IdInstanciaTribunal, p.Forum, p.Distribuicao
  FROM Processo p 
 WHERE LEN(p.Distribuicao) = 10
order by id desc

--- query para ver parametros para captura imagem captcha
select * from EquipamentoProcessamentoParametro
where IdEquipamentoProcessamento = 26
and Descricao = 'Posicao Imagem PJe V2'

--- query na tabela SolicitacaoCaptura
select * from SolicitacaoCaptura 
 where CriadoEm >= '2020/08/13' and CriadoEm <= '2020/08/14'

--- query para pesquisar por data e a partir de hora específica

select p.Numero
	  ,format(hsp.Data, ('dd-MM-yyyy HH:mm:ss')) As CaptReglare
	  ,tj.Sigla
	  ,p.Vara
  from HistoricoStatusProcesso hsp
  join Processo p on p.id = hsp.IdProcesso 
  join TribunalJustica tj on tj.Id = p.IdTribunalJustica
 where hsp.IdStatus = 23 --<-- Capturado -- 21.Distribuido -- 23.Movimentado
   and cast(hsp.Data AS date) >= '2022-01-01' --<-- ATENTE PARA A DATA
   and datepart(hh,hsp.Data) >= 15 and datepart(hh,hsp.Data) <= 23 
 order by cast(hsp.Data AS date)

---- query tabela expressao regular
select * from SolicitacaoLocalizacao

insert into solicitacaolocalizacao (criadoem, criadopor, alteradoem, alteradopor, descricao, idstatus)
values (getdate(), 1021, getdate(), 1021, 'poc expresso vera cruz ltda', 1);

select * from termolocalizacao

insert into termolocalizacao (criadoem, criadopor, alteradoem, alteradopor, idsolicitacaolocalizacao, termo, sequencia, ativo, baixarcopia, capturarmovimento)
values (getdate(), 1021, getdate(), 1021, 4, 'expresso vera cruz', 1, 1, 0, 1);

select * from termoexpressaoregular

insert into termoexpressaoregular (criadoem, criadopor, alteradoem, alteradopor, idtermolocalizacao, expressao, afirmacao, sequencia, ativo)
values (getdate(), 1021, getdate(), 1021, 6, '\bexpresso\b.{0,20}\bvera\b.{0,20}\bcruz\b.{0,20}\bltda', 1, 1, 1);


---- query para inserir parametros na tabela TERMOTRIBUNALPROCESSO para expressao regular 

--5 ---> TIM 

insert into termotribunal values (getdate(),1021,null,null,6,5022,17,1)

termo: 5 "TIM" tribunal: 4002 
insert into termotribunal values (getdate(),1021,null,null,5,4002,5,1)

termo: 5 "TIM" tribunal: 5009 
insert into termotribunal values (getdate(),1021,null,null,5,5009,19,1)


---- query SOLICITACAOCAPTURA
select sc.Id, sc.CriadoEm, sc.Descricao, sc.IdStatus, 
       ssc.Descricao, sc.DataTerminoUltimaCaptura, 
	   sc.CapturarDistribuicao,
	   sc.DataUltimoProcessamento, sc.IdEquipamentoProcessamento
  from SolicitacaoCaptura sc
  join StatusSolicitacaoCaptura ssc on ssc.Id = sc.IdStatus

---- query recupera dados do equipamento que ira processar as pesquisas
select * from EquipamentoProcessamento ep
 where ep.address = '782BCBED96BD'
   and ep.ativo = 1

---- query QuantidadeProcessamento Em Aberto por Equipamento
select * from ProcessamentoCaptura pc
 where pc.IdEquipamentoProcessamento = 26
   and pc.DataTermino is null 

---- query Quantidade Processamento Em Aberto por Tribunal e Equipamento
select count(*) from processamentoCaptura pc
 where pc.IdEquipamentoProcessamento = 26
   and pc.IdTribunal = 2002
   and pc.IdTecnologiaSite = 17
   and pc.DataTermino is null

---- query posicao imagem captcha
select * from EquipamentoProcessamentoParametro
where IdEquipamentoProcessamento = 26
and Descricao = 'Posicao Imagem PJe V2'

---- query para pesquisar por upper case
select 
       p.Id,
	   p.Forum,
	   p.Comarca,
	   p.Vara,
	   p.OrgaoJulgador,
	   p.UF
  from Processo p
 where p.IdEquipamentoProcessamento = 25
 and p.OrgaoJulgador = upper(p.OrgaoJulgador) collate SQL_Latin1_General_CP1_CS_AS

---- query analise forum vara comarca

select p.Id,
       p.IdSolicitacaoCaptura,
	   p.Numero,
	   p.IdTribunalJustica,
	   p.Forum,
	   p.Vara,
	   p.Comarca,
	   p.OrgaoJulgador,
	   sc.DataTerminoUltimaCaptura
  from Processo p
  join SolicitacaoCaptura sc on sc.Id = p.IdSolicitacaoCaptura
where p.IdSolicitacaoCaptura in
(select sc.Id
  from SolicitacaoCaptura sc
  where sc.DataTerminoUltimaCaptura >= '2020-09-29' and sc.DataTerminoUltimaCaptura <= '2020-10-06 23:59:59')
and p.idEquipamentoProcessamento = 26

---- para criar nova coluna na tabela

ALTER TABLE ProcessoCapturado
ADD OrgaoJulgador varchar(200) NULL;

ALTER TABLE DiarioOficial
ADD HoraInicio time(3);

ALTER TABLE ProcessoMovimento 
ADD Integrado bit 
DEFAULT 0 NOT NULL;

---- para excluir uma coluna

ALTER TABLE ProcessoCapturado
DROP COLUMN OrgaoJulgador;


---- exemplos criar nova tabela

CREATE TABLE DiarioOficial (
    Id int IDENTITY(1,1) PRIMARY KEY,
	CriadoEm datetime,
    Tribunal varchar(250),
	NumeroDiario varchar(30),
	DataDisponibilizacao varchar(100),
    NomeArquivo varchar(100),
	DataDisp datetime,
    InicioLeitura datetime,
    FimLeitura datetime
);

CREATE TABLE DiarioOficialProcessos (
Id int IDENTITY(1,1) PRIMARY KEY,
	IdDiarioOficial int,
	CriadoEm datetime,
	Numero varchar(30),
	IdStatus smallint
);

CREATE UNIQUE INDEX idx_tribunalnum
ON DiarioOficial (Tribunal, NumeroDiario);

CREATE UNIQUE INDEX idx_iddiarionumer
  ON DiarioOficialProcessos (IdDiarioOficial, Numero);

---- para encontrar duplicidades

select p.Numero, count(p.Numero)
  from Processo p
 group by p.Numero
having count(p.Numero)>1
 order by p.Numero

---- para zerar a tabela




---- clausula HAVING

select count(dop.Numero), 
       dop.IdDiarioOficial
  from DiarioOficialProcessos dop
--join DiarioOficial do on do.Id = dop.IdDiarioOficial
--WHERE dop.CriadoEm BETWEEN '20210216 00:00' AND '20210216 23:59:59'
--AND (PATINDEX('%[a-zA-Z]%', dop.Numero) <> 0)
group by dop.Numero, dop.IdDiarioOficial
HAVING COUNT(dop.Numero) > 2;

select count(dop.numero), 
       dop.Numero,
	   dop.IdDiarioOficial
  from DiarioOficialProcessos dop
where dop.IdDiarioOficial = 325
group by dop.Numero, dop.IdDiarioOficial
having count(dop.numero) > 1
order by dop.Numero

select * 
  from EquipamentoProcessamento

select *
  from EquipamentoProcessamentoParametro
where IdEquipamentoProcessamento = 26

---- query inserir parametros para maquina 

INSERT INTO EquipamentoProcessamentoTribunal(CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,IdTribunal,IdCliente,Sequencia,QuantidadeTask,
Ativo,IdTecnologiaSite,BaixarCopia,CapturarDado,CapturarMovimento,CapturarDistribuicao,ManterLogin,CopiaDocumentoUnico)
VALUES(GETDATE(),1,GETDATE(),1,31,2,NULL,5,6,1,21,1,0,1,1,1,1);


INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Posicao Imagem PJe V2','0#0#0#0');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Pasta Base Firefox','C:\Program Files\Mozilla Firefox\firefox.exe');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Posicao Captcha BA','100#0#120#20');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Posicao Captcha BA - primeira vez','100#0#120#20');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Pasta Imagem Resposta Download','C:\Projetos\ReglareDownloads');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Pasta Base Profile Firefox 68.0.2 (32-bits)','C:\Users\carlos.silva\AppData\Roaming\Mozilla\Firefox\Profiles\ekxcwqeq.default-release');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Quantidade Blocagem Pixel Captach TRT','3');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Exibir Navegador','Sim');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Gerar .json Retorno Distribuicao','true');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Pasta Gerar .json Retorno Distribuicao','C:\Pastas de Trabalho\Projetos\Captura Dados Processo\JsonDistribuicao');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Pasta Gerar .json Captura Distribuicao','C:\Pastas de Trabalho\Projetos\Captura Dados Processo\JsonCaptura');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,31,'Posicao Imagem TJRJ','-60#0#0#0');

select *
  from EquipamentoProcessamentoParametro
where IdEquipamentoProcessamento = 26

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Posicao Imagem PJe V2','0#0#0#0');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Pasta Base Firefox','C:\Program Files\Mozilla Firefox\firefox.exe');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Pasta Base Firefox','C:\Program Files\Mozilla Firefox\firefox.exe');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Posicao Captcha BA','100#0#120#20');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Posicao Captcha BA - primeira vez','100#0#120#20');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Pasta Imagem Resposta Download','C:\Pastas de Trabalho\Projetos\Captura Dados Processo\Configuracoes\ImagemDownload');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Pasta Base Profile Firefox 68.0.2 (32-bits)','C:\Users\admomnijus\AppData\Roaming\Mozilla\Firefox\Profiles\wrbc3o0m.default-release');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Quantidade Blocagem Pixel Captach TRT','3');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Exibir Navegador','Sim');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Gerar .json Retorno Distribuicao','true');

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Pasta Gerar .json Retorno Distribuicao','C:\Pastas de Trabalho\Projetos\Captura Dados Processo\JsonDistribuicao')

INSERT INTO EquipamentoProcessamentoParametro (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdEquipamentoProcessamento,Descricao,Valor)
VALUES(GETDATE(),1,GETDATE(),1,29,'Pasta Gerar .json Captura Distribuicao','D:\Pastas de Trabalho\Projetos\Captura Dados Processo\JsonCaptura')

---- exemplo de CAST
select pc.IdEquipamentoProcessamento, 
       cast(pc.DataInicio AS DATE) as DataCaptura,
	   count(Cast(pc.DataInicio AS DATE)) as TotalPorData
  from ProcessamentoCaptura pc
where cast(pc.DataInicio AS DATE) = '2021-04-12'
where cast(pc.DataInicio AS DATE) >= '2021-04-01' and cast(pc.DataInicio AS DATE) <= '2021-04-05'
group by pc.IdEquipamentoProcessamento, cast(pc.DataInicio AS DATE)
order by pc.IdEquipamentoProcessamento, cast(pc.DataInicio AS DATE)

---- Traduçao da Query abaixo:
---- Pegar solicitacoes para Capturar Distribuicao

SolicitacaoCaptura.Where(sc => (sc.Status == StatusSolicitacaoCaptura.LiberadoProcessamento  ||
                                sc.Status == StatusSolicitacaoCaptura.ProcessadoComPendencia ||
                                sc.Status == StatusSolicitacaoCaptura.EmProcessamento) &&
                               (sc.EquipamentoProcessamento == null || sc.EquipamentoProcessamento == configuracao.EquipamentoProcessamento) &&
                                sc.CapturarDistribuicao &&
							   !sc.Capturas.Any(c => c.DataTermino == null) &&
								sc.Processos.Any(p => p.Tribunal.Id == configuracao.Tribunal.Id &&
								p.TecnologiaSite.Id == configuracao.Tecnologia.Id &&
							   (p.Status == StatusProcesso.Pendente || p.Status == StatusProcesso.EmProcessamento))).
							   OrderBy(sc => sc.DataTerminoUltimaCaptura).ToList();

select sc.Id,
       sc.Descricao,
	   sc.IdStatus,
	   sc.CapturarDado,
	   sc.CapturarDistribuicao,
	   sc.DataTerminoUltimaCaptura,
	   sc.DataUltimoProcessamento
  from SolicitacaoCaptura sc
 where sc.IdStatus in (3,12,4)
   and (sc.IdEquipamentoProcessamento = 31 or sc.IdEquipamentoProcessamento is null)
   and sc.CapturarDistribuicao = 1
   and not exists (select pc.IdSolicitacaoCaptura from ProcessamentoCaptura pc where pc.IdSolicitacaoCaptura = sc.id and pc.DataTermino is null)
   and sc.Id in (select p.IdSolicitacaoCaptura from Processo p where p.IdSolicitacaoCaptura = sc.id and p.IdTribunalJustica = 2 
                 and p.IdTecnologiaSite = 21 and 
				(p.IdStatus = 1 or p.IdStatus = 10))

---- Pegar solicitacoes para Capturar Processo

SolicitacaoCaptura.Where(sc => (sc.Status == StatusSolicitacaoCaptura.LiberadoProcessamento ||
                                sc.Status == StatusSolicitacaoCaptura.ProcessadoComPendencia ||
                                sc.Status == StatusSolicitacaoCaptura.EmProcessamento) &&
                               (sc.EquipamentoProcessamento == null || sc.EquipamentoProcessamento == configuracao.EquipamentoProcessamento) &&
                               !sc.CapturarDistribuicao &&
                               !sc.Capturas.Any(c => c.DataTermino == null) &&
                                sc.Processos.Any(p => p.Tribunal.Id == configuracao.Tribunal.Id &&
                                p.TecnologiaSite.Id == configuracao.Tecnologia.Id &&
                               (p.Status == StatusProcesso.Pendente || p.Status == StatusProcesso.EmProcessamento))).
							   OrderBy(sc => sc.DataTerminoUltimaCaptura).ToList();

select sc.Id,
       sc.Descricao,
	   sc.IdStatus,
	   sc.CapturarDado,
	   sc.CapturarDistribuicao,
	   sc.DataTerminoUltimaCaptura,
	   sc.DataUltimoProcessamento
  from SolicitacaoCaptura sc
 where sc.IdStatus in (3,12,4)
   and (sc.IdEquipamentoProcessamento = 31 or sc.IdEquipamentoProcessamento is null)
   and sc.CapturarDistribuicao = 1
   and not exists (select pc.IdSolicitacaoCaptura from ProcessamentoCaptura pc where pc.IdSolicitacaoCaptura = sc.id and pc.DataTermino is null)
   and sc.Id in (select p.IdSolicitacaoCaptura from Processo p where p.IdSolicitacaoCaptura = sc.id and p.IdTribunalJustica = 2 




---- query para transferir o processo para a omnijus
session.Query<Processo>()
       .Timeout(100)
       .Where(x => x.Status == StatusProcesso.Capturado &&
       x.Solicitacao.CapturarDistribuicao &&
                                            //x.Classe == "ATOrd" &&
                                            //x.Area.Contains("Juizado Especial Cível") &&
                                            !x.Historicos.Any(hp => hp.Status == StatusProcesso.EntreguePlataformaOmniJus) &&
                                            x.Historicos.Any(hp => hp.Status == StatusProcesso.DownloadDisponivel) &&
                                            //x.Partes.Any(p => p.Nome.ToUpper().Contains("PIC")) &&
                                            //x.Distribuicao.Contains("02/2021") &&
                                            //x.Numero.Contains(".8.08.") &&
                                            //(x.Id == 1889042 || x.Id == 1889041 || x.Id == 1889039 || x.Id == 1889038 || x.Id == 1889037 || x.Id == 1889034 || x.Id == 1889033 ) &&
                                            (x.Id == 1889349) &&
                                            x.ProcessoPecas.Any(p => p.Movimento != null)
                                            )
                                .ToList();
								
								
								
								
								
								

---- outra query traduzida

_session.Query<Processo>()
        .Where(x => x.Status == StatusProcesso.Capturado &&
       x.PossuiDocumento &&
       x.Solicitacao.CapturarDistribuicao &&
      (x.EquipamentoProcessamento == null || x.EquipamentoProcessamento == equipamento) &&
      !x.Historicos.Any(h => h.Status == StatusProcesso.ProcessoDesmembrado)).ToList();

select p.Id , 
       p.Numero , 
	   p.Forum , 
	   p.Vara , 
	   p.IdFaixaNumeroProcesso  
  from Processo p inner join SolicitacaoCaptura solicitaca1_ on p.idSolicitacaoCaptura=solicitaca1_.Id 
where p.IdStatus= 2
  and p.PossuiDocumento=1 
  and solicitaca1_.CapturarDistribuicao=1 
  and (p.IdEquipamentoProcessamento is null or p.IdEquipamentoProcessamento=34) 
  and  not (exists (select hpp.Id from HistoricoStatusProcesso hpp where p.Id=hpp.IdProcesso and hpp.IdStatus=15))

----

---- sequencia para verificar parametros para captura dos processos
select * from EquipamentoProcessamentoTribunal 
where IdEquipamentoProcessamento = 26
and Ativo = 1

update EquipamentoProcessamentoTribunal
set ativo = 0
where id = 3234

select top 10 * 
  from SolicitacaoCaptura
order by id desc

select *
  from Processo p
where p.IdSolicitacaoCaptura = 1380

select * 
  from InstanciaTribunal
where id = 5311

select *
  from ForumFaixaNumeroProcesso
where id = 5313

select *
  from ForumFaixaNumeroAno
where IdForumFaixaNumeroProcesso = 5313

select *
  from ForumTribunal
where id = 3740

select * 
  from TribunalJustica
where id = 2

select *
  from ForumTribunal
where id = 3740

select * 
  from TermoTribunal
where IdTribunal = 2
order by id desc

select *
  from TermoLocalizacao
where id in (5,6,8)

select * 
  from SolicitacaoLocalizacao
where id in (3,4,6)

select *
  from TermoExpressaoRegular

select * 
  from Processo p
 where p.numero in
 ('5006906-15.2021.8.08.0024',
  '5006832-58.2021.8.08.0024')

select top 10 * 
  from HistoricoStatusProcessoCopia hspc
 where hspc.IdProcessoCopia in (145679,145680)

select *
  from HistoricoStatusProcesso hsp
  join StatusProcesso sp on sp.Id = hsp.IdStatus 
 where hsp.IdProcesso in (145679,145680)
order by hsp.IdProcesso, hsp.IdStatus desc

select *
  from ProcessoPeca pp
 where pp.IdProcesso in (145679,145680)
order by pp.IdProcesso desc

select *
  from ProcessoMovimento pm
 where pm.Numero in 
  ('0816321-26.2021.8.19.0038',
  '0815757-47.2021.8.19.0038')
order by id desc

---- query para pegar processos a desmembrar o arquivo pdf
Processo
.Where(x => x.Status == StatusProcesso.Capturado &&
            x.PossuiDocumento &&
            x.Solicitacao.CapturarDistribuicao &&
            (x.EquipamentoProcessamento == null || x.EquipamentoProcessamento == equipamento) &&
            !x.Historicos.Any(h => h.Status == StatusProcesso.ProcessoDesmembrado))


  select pro.Numero
        ,pro.Id
		,pro.IdSolicitacaoCaptura
		,pro.Comarca
		,pro.IdStatus
		,pro.PossuiDocumento
		,sc.CapturarDistribuicao
		,pro.IdEquipamentoProcessamento
  from  Processo pro
  join	SolicitacaoCaptura sc on sc.id = pro.IdSolicitacaoCaptura
 where pro.IdStatus = 2
   and pro.PossuiDocumento = 1  
   and sc.CapturarDistribuicao = 1
   and (pro.IdEquipamentoProcessamento = 26 or pro.IdEquipamentoProcessamento is null)
   and not exists (select hsp.IdProcesso from HistoricoStatusProcesso hsp where hsp.IdProcesso = pro.id and hsp.IdStatus = 15)


-------------------------------------------------------------------------------------------
select top 100 
       sc.id, 
	   sc.Descricao, 
	   sc.IdStatus, 
	   sc.IdEquipamentoProcessamento,
	   ssc.Descricao,
	   sc.DataUltimoProcessamento,
	   sc.DataTerminoUltimaCaptura
  from SolicitacaoCaptura sc
  join StatusSolicitacaoCaptura ssc on ssc.Id = sc.IdStatus
 order by id desc

 select p.Id,
        p.Numero,
		p.IdSolicitacaoCaptura,
        p.IdTribunalJustica,
		p.IdTecnologiaSite,
		p.IdInstanciaTribunal,
		p.Forum,
		p.IdStatus,
		sp.Descricao,
		p.IdEquipamentoProcessamento
   from Processo p
   join StatusProcesso sp on sp.Id = p.IdStatus
  where p.IdSolicitacaoCaptura in (1378)
  --and p.numero like '999999%'

select ept.IdEquipamentoProcessamento,
       ept.IdTribunal,
	   ept.IdTecnologiaSite
  from EquipamentoProcessamentoTribunal ept
 where IdEquipamentoProcessamento in (26)
 and Ativo = 1

select it.IdTribunal,
       it.Id,
       it.Descricao,
       it.URL,
       ts.Descricao,
       uf.Sigla,
	   ts.Id,
	   ts.Descricao
  from InstanciaTribunal it
  join TecnologiaSite ts on ts.id = it.IdTecnologiaSite
  join TribunalJustica tj on tj.Id = it.IdTribunal 
  join Uf uf on uf.id = tj.IdUF
 where it.IdTribunal = 5008
 and ts.Id = 20
order by tj.Id

select * 
  from TermoTribunal
where IdTribunal = 2

select * 
  from TermoLocalizacao
where id in (8)

select * 
  from TermoExpressaoRegular
where IdTermoLocalizacao in (8)

select *
  from EquipamentoProcessamento
where id = 26

select ept.Id,
       ept.IdTribunal,
	   ept.IdTecnologiaSite,
	   ept.BaixarCopia,
	   ept.HoraInicio,
	   ept.HoraFim
  from EquipamentoProcessamentoTribunal ept
where IdEquipamentoProcessamento = 26
and ept.Ativo = 1

<------------- QUERY PARA PEGAR O 1 REGISTRO GERADO A PARTIR DO RELACIONAMENTO DA 1 TABELA

select sc.Id, sc.CriadoEm, sc.Descricao, Processos.Numero
  from SolicitacaoCaptura sc
  cross apply
        (select top 1 IdSolicitacaoCaptura, Numero 
		   from Processo p where p.IdSolicitacaoCaptura = sc.Id) Processos
where cast(sc.CriadoEm as date) >= '2022-01-01'
order by sc.Id desc


<------------- PESQUISAR REGISTROS SEM COLUNA EM BRANCO USANDO LTRIM

select upper(p.OrgaoJulgador) as ORGAO_JULGADOR, 
       upper(p.Vara) as VARA, 
	   upper(p.Forum) as FORUM, 
	   upper(p.Comarca) as COMARCA, 
	   p.IdTribunalJustica,
	   p.IdInstanciaTribunal,
	   p.IdTecnologiaSite 
from Processo p 
where p.OrgaoJulgador is not null 
   and p.Comarca is not null
   and p.Vara is not null
   and p.Forum is not null
   and not ltrim(rtrim(p.Forum)) = ''
   and not ltrim(rtrim(p.Comarca)) = ''
   and not ltrim(rtrim(p.Vara)) = ''
 group by p.OrgaoJulgador, p.Vara, p.Forum, p.Comarca,  p.IdTribunalJustica,
	      p.IdInstanciaTribunal, p.IdTecnologiaSite 


<------------- QUERY AUTOMATIZADA PARA GERAR NUMERACAO NOS TRIBUNAIS ----->

begin transaction;

declare @descricao varchaR(100);
declare @Forum varchar(4);
declare @Numeracao varchar(7);
declare @IdEquipamentoProcessamento int;
declare @IdSolicitacao int;
declare @NumeroProcesso varchar(25);
declare @IdFaixaNumeracao int;
declare @idtribunal int;
declare @idInstanciaTribunal int;
declare @siglaTribunal varchar(10);
declare @identificacaoProcesso varchar(10);
declare @IdTecnologiaSite int;
declare @ano int;
declare @idForum int;
declare @ultimoNumeroFaixa int;

--===================================================================================================
-- Configura as variaveis de Acordo com o Numero do Processo que será gerado o intervalo
-- 0800601-82.2021.8.19.0211 <-- exemplo
-- 5000286-58.2021.8.08.0065 <-- exemplo
-- 0012765-98.2021.8.19.0054
--===================================================================================================
--select @identificacaoProcesso = '8.19'
select @identificacaoProcesso = '8.08'
select @ano = 2021;
select @IdTecnologiaSite = 20;  
--select @Numeracao = '0800000';
select @Numeracao = '0500000';
--select @ultimoNumeroFaixa = 0800600;
select @ultimoNumeroFaixa = 5000285;
--select @Forum = '0211';
select @Forum = '0065';
--===================================================================================================

select @idtribunal = id , @siglaTribunal = Sigla
   from TribunalJustica
where IdentificacaoProcesso = @identificacaoProcesso;

select @idInstanciaTribunal = id 
		--,@IdTecnologiaSite = IdTecnologiaSite
   from InstanciaTribunal
where IdTribunal = @idtribunal
and Descricao in ('1ª e 2ª Instância', '1ª instância','1ª Instância')
and (@IdTecnologiaSite is null or @IdTecnologiaSite = IdTecnologiaSite);

select @idForum = id 
   from ForumTribunal ft
where ft.IdTribunal = @idtribunal
and ft.Numero = @Forum;


--===================================================================================================
--Incluir a Faixa de Numerçao
--===================================================================================================
insert into ForumFaixaNumeroProcesso (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdForumTribunal
							,QuantidadeProcessoPendente,Ativo,QuantidadeProcessoNaoLocalizado,FaixaNumeroProcesso
							,IdInstanciaTribunal,QuantidadeRepeticaoProcessamento,QuantidadeDiaRetrocessoPesquisa)
values (getdate(),1,null,null,@idForum,1,1,1,@Numeracao,@idInstanciaTribunal,1,3);

select @IdFaixaNumeracao = @@IDENTITY;
--===================================================================================================

--===================================================================================================
--Incluir a Faixa de Numerçao no Ano
--===================================================================================================
insert into ForumFaixaNumeroAno (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdForumFaixaNumeroProcesso,Ano,UltimoNumeroProcesso)
values (getdate(),1,null,null,@IdFaixaNumeracao,@ano,@ultimoNumeroFaixa);
--===================================================================================================

--===================================================================================================
--Incluir a Solicitação de Captura
--===================================================================================================
select @descricao = 'Captura Distribuição - ' + @siglaTribunal + ' - ' + @Forum + ' - ' + @Numeracao;

insert into SolicitacaoCaptura values
(getdate(),1,@descricao,1,3,null,0,1,0,0,0,1,1,0,0,null,null,null)

select @IdSolicitacao = @@IDENTITY;
--===================================================================================================
select @NumeroProcesso = '9999999-00.' + convert(varchar(4),@ano) + '.' + @identificacaoProcesso + '.' + @Forum;

insert into Processo (IdSolicitacaoCaptura,Numero,IdTribunalJustica,IdStatus,Eletronico,IdTecnologiaSite,IdFaixaNumeroProcesso, IdInstanciaTribunal, justicagratuita)
values (@IdSolicitacao,@NumeroProcesso,@idtribunal,1,1,@IdTecnologiaSite,@IdFaixaNumeracao, @idInstanciaTribunal, 0)
--===================================================================================================

--rollback transaction;
commit transaction;

---- 17.11.2021
begin transaction;

declare @descricao varchaR(100);
declare @Forum varchar(4);
declare @Numeracao varchar(7);
declare @IdEquipamentoProcessamento int;
declare @IdSolicitacao int;
declare @NumeroProcesso varchar(25);
declare @IdFaixaNumeracao int;
declare @idtribunal int;
declare @idInstanciaTribunal int;
declare @siglaTribunal varchar(10);
declare @identificacaoProcesso varchar(10);
declare @IdTecnologiaSite int;
declare @ano int;
declare @idForum int;
declare @ultimoNumeroFaixa int;

--===================================================================================================
-- Configura as variaveis de Acordo com o Numero do Processo que será gerado o intervalo
-- 0800601-82.2021.8.19.0211 <-- exemplo
-- 5000286-58.2021.8.08.0065 <-- exemplo
-- 0800429-67.2021.8.19.0203	
--===================================================================================================
select @identificacaoProcesso = '8.19'
select @ano = 2022;
select @IdTecnologiaSite = 20;  
select @Numeracao = '0800000';
select @ultimoNumeroFaixa = 0800428;
select @Forum = '0203';
--===================================================================================================

select @idtribunal = id , @siglaTribunal = Sigla
   from TribunalJustica
where IdentificacaoProcesso = @identificacaoProcesso;

select @idInstanciaTribunal = id 
		--,@IdTecnologiaSite = IdTecnologiaSite
   from InstanciaTribunal
where IdTribunal = @idtribunal
and Descricao in ('1ª e 2ª Instância', '1ª instância','1ª Instância')
and (@IdTecnologiaSite is null or @IdTecnologiaSite = IdTecnologiaSite);

select @idForum = id 
   from ForumTribunal ft
where ft.IdTribunal = @idtribunal
and ft.Numero = @Forum;


--===================================================================================================
--Incluir a Faixa de Numerçao
--===================================================================================================
insert into ForumFaixaNumeroProcesso (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdForumTribunal
							,QuantidadeProcessoPendente,Ativo,QuantidadeProcessoNaoLocalizado,FaixaNumeroProcesso
							,IdInstanciaTribunal,QuantidadeRepeticaoProcessamento,QuantidadeDiaRetrocessoPesquisa)
values (getdate(),1,null,null,@idForum,1,1,1,@Numeracao,@idInstanciaTribunal,1,3);

select @IdFaixaNumeracao = @@IDENTITY;
--===================================================================================================

--===================================================================================================
--Incluir a Faixa de Numerçao no Ano
--===================================================================================================
insert into ForumFaixaNumeroAno (CriadoEm,CriadoPor,AlteradoEm,AlteradoPor,IdForumFaixaNumeroProcesso,Ano,UltimoNumeroProcesso)
values (getdate(),1,null,null,@IdFaixaNumeracao,@ano,@ultimoNumeroFaixa);
--===================================================================================================

--===================================================================================================
--Incluir a Solicitação de Captura
--===================================================================================================
select @descricao = 'Captura Distribuição - ' + @siglaTribunal + ' - ' + @Forum + ' - ' + @Numeracao;

insert into SolicitacaoCaptura values
(getdate(),1,@descricao,1,3,null,0,1,0,0,0,1,1,0,0,null,null,null)

select @IdSolicitacao = @@IDENTITY;
--===================================================================================================
select @NumeroProcesso = '9999999-00.' + convert(varchar(4),@ano) + '.' + @identificacaoProcesso + '.' + @Forum;

insert into Processo (IdSolicitacaoCaptura,Numero,IdTribunalJustica,IdStatus,Eletronico,IdTecnologiaSite,IdFaixaNumeroProcesso, IdInstanciaTribunal, justicagratuita)
values (@IdSolicitacao,@NumeroProcesso,@idtribunal,1,1,@IdTecnologiaSite,@IdFaixaNumeracao, @idInstanciaTribunal, 0)
--===================================================================================================

--rollback transaction;
commit transaction;

