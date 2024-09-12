
## CheckList

### Usuário
    [X] Criar a entidade
    [] Criar alguns usuários para teste
    [X] Os usuários deve ter funcões (Gerente)
    [] *Controller* Report: A API deve fornecer endpoints para gerar relatórios de desempenho, como o número médio de tarefas concluídas por usuário nos últimos 30 dias.
    [] *UseCase* gerar relatórios de desempenho, como o número médio de tarefas concluídas por usuário nos últimos 30 dias
    [] *UseCase* Os relatórios devem ser acessíveis apenas por usuários com uma função específica de "gerente". 


### Projeto
    [X] Criar entidade
    [X] *Controller* GetAllProjects: listar todos os projetos do usuário
    [X] *Controller* CreateProject: criar um novo projeto
    [X] *Controller* RemoveProject: Remove o projeto
    [X] *UseCase* Um projeto não pode ser removido se ainda houver tarefas pendentes associadas a ele
    [X] *UseCase* Caso o usuário tente remover um projeto com tarefas pendentes, a API deve retornar um erro e sugerir a conclusão ou remoção das tarefas primeiro.
    [X] *UseCase* Cada projeto tem um limite máximo de 20 tarefas. Tentar criar com mais tarefas do que o limite deve resultar em um erro.
    [X] *UseCase* Cada projeto tem um limite máximo de 20 tarefas. Tentar adicionar mais tarefas do que o limite deve resultar em um erro.


### Tarefas
    [X] Criar entidade
    [X] *Controller* GetAllWorkItems: listr dodas as Tarefas de um projeto especifico
    [X] *Controller* CreateWorkItem: adicionar uma nova tarefa a um projeto
    [X] *Controller* UpdateWorkItem: atualizar o status ou detalhes e add comentarios de uma tarefa
    [X] *Controller* DeleteWorkItem: remover uma tarefa de um projeto
    [X] *UseCase* Cada tarefa deve ter uma prioridade atribuída
    [X] *UseCase* Não é permitido alterar a prioridade de uma tarefa depois que ela foi criada.
    [X] *UseCase* Cada vez que uma tarefa for atualizada (status, detalhes, comentarios), a API deve registrar um histórico de alterações para a tarefa.
    [X] *UseCase* O histórico de alterações deve incluir informações sobre o que foi modificado, a data da modificação e o usuário que fez a modificação.
    [X] *UseCase* Os usuários podem adicionar comentários a uma tarefa para fornecer informações adicionais.

### Validações
    [] Tenha pelo menos 80% de cobertura de testes de unidade para validar suas regras de negócio
    [] *DOCKER* O projeto deve executar no docker e as informações de execução via terminal devem estar disponíveis no README.md do projeto
    [] Subir banco de dados postgres
    [] Criar migrations
    [] add fluente vlidade
    [] add mappers
    [X] add healthcheck
    [X] Mudar as configuração dol program para classes expecificas
 
### Fase 2: Refinamento
        Acredito que para o próximo refinamento focaria na parte do usuário, para ter melhor definição de como de que esse usuário realmente representa para o negócio, quais os níveis teriam? quais outras interações teriam? 

### Melhoraria no projeto
        Dependendo da utilização e da necessidade de acesso poderia colocar esse projeto em um EKS na AWS com helm,  
        mas se for algo com possível necessidade de escalar poderia optar pelo AWS Elastic Beanstalk. 
        Como melhoria poderiá sugeriri, além do que não pode finalizar como a integração com o banco de dados,  
        Iria sugerir adicionar o FluenteValidade para validar os DTOs com mais detalhes.
        Talvez usar o auto mapper para converter os DTOs em Emtities.
        Colocar para roda no devContainer para facilitar a inclusão de novos membros no time. 
        Incluiria as configurações no Code Coverage para ignorar as classes de suporte como os exceptions, serviceRegiste ... 
        Adicionaria o sonar para rodar no pre-push para garantir a qualidade do código que estaria subindo para o controle de versão. 


code coverege
dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings

reportgenerator "-reports:Test\TaskManagement.UnitTest\TestResults\*\*.cobertura.xml" "-targetdir:coverageresults" -reporttypes:HtmlSummary -title:IntegrationTest -tag:v1.4.5


docker  
docker compose up --build -d

http://localhost:8080/health-json