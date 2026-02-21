INSERT INTO
  "Posts" (
    "Id",
    "Title",
    "Content",
    "Slug",
    "CreatedAt",
    "UpdatedAt"
  )
VALUES
  (
    'a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d',
    'Введение в Angular Signals',
    'В этой статье мы подробно разберем, как работают сигналы в Angular 17+ и почему они меняют подход к управлению состоянием...',
    'introduction-to-angular-signals',
    NOW () - INTERVAL '10 days',
    NOW () - INTERVAL '10 days'
  ),
  (
    'b2c3d4e5-f6a7-4b6c-9d0e-1f2a3b4c5d6e',
    'Преимущества FSD архитектуры',
    'Feature-Sliced Design помогает масштабировать фронтенд приложения. Разберем слои entities, features и widgets на практике...',
    'fsd-architecture-benefits',
    NOW () - INTERVAL '9 days',
    NOW () - INTERVAL '8 days'
  ),
  (
    'c3d4e5f6-a7b8-4c7d-0e1f-2a3b4c5d6e7f',
    'Чистая архитектура на .NET 8',
    'Как правильно разделить Domain, Application и Infrastructure слои в вашем Web API проекте...',
    'clean-architecture-dotnet-8',
    NOW () - INTERVAL '7 days',
    NOW () - INTERVAL '7 days'
  ),
  (
    'd4e5f6a7-b8c9-4d8e-1f2a-3b4c5d6e7f8a',
    'Работа с PostgreSQL в Docker',
    'Быстрый старт с Postgres через docker-compose. Настройка пользователей, прав доступа и персистентности данных...',
    'postgresql-docker-guide',
    NOW () - INTERVAL '6 days',
    NOW () - INTERVAL '6 days'
  ),
  (
    'e5f6a7b8-c9d0-4e9f-2a3b-4c5d6e7f8a9b',
    'NgRx Signal Store: Будущее стейт-менеджмента',
    'Узнайте, как интегрировать ngrx/signals в ваши Angular проекты для более лаконичного кода...',
    'ngrx-signal-store-future',
    NOW () - INTERVAL '5 days',
    NOW () - INTERVAL '4 days'
  ),
  (
    'f6a7b8c9-d0e1-4f0a-3b4c-5d6e7f8a9b0c',
    'Советы по оптимизации Entity Framework',
    'Разбираем AsNoTracking, Split Queries и правильное использование индексов для ускорения ваших запросов...',
    'ef-core-optimization-tips',
    NOW () - INTERVAL '4 days',
    NOW () - INTERVAL '4 days'
  ),
  (
    '0a1b2c3d-4e5f-6a7b-8c9d-0e1f2a3b4c5d',
    'Создание кастомных UI компонентов в Taiga UI',
    'Как использовать мощную библиотеку Taiga UI для создания доступных и красивых интерфейсов...',
    'taiga-ui-custom-components',
    NOW () - INTERVAL '3 days',
    NOW () - INTERVAL '3 days'
  ),
  (
    '1b2c3d4e-5f6a-7b8c-9d0e-1f2a3b4c5d6e',
    'Зачем нужен RabbitMQ в микросервисах',
    'Обмен сообщениями между сервисами, гарантия доставки и асинхронная обработка данных...',
    'rabbitmq-microservices',
    NOW () - INTERVAL '2 days',
    NOW () - INTERVAL '2 days'
  ),
  (
    '2c3d4e5f-6a7b-8c9d-0e1f-2a3b4c5d6e7f',
    'Unit-тестирование в C# с помощью xUnit',
    'Пишем первые тесты, используем Moq для имитации зависимостей и FluentAssertions для красивых проверок...',
    'unit-testing-xunit-moq',
    NOW () - INTERVAL '1 day',
    NOW () - INTERVAL '12 hours'
  ),
  (
    '3d4e5f6a-7b8c-9d0e-1f2a-3b4c5d6e7f8a',
    'Docker Compose для Fullstack разработчика',
    'Связываем Angular, .NET API и Postgres в одну инфраструктуру одним файлом...',
    'docker-compose-fullstack',
    NOW (),
    NOW ()
  ),
  (
    gen_random_uuid (),
    'Масштабирование SignalStore',
    'Разбираем архитектурные паттерны для управления огромными объемами данных на клиенте...',
    'scaling-signal-store',
    NOW () - INTERVAL '11 days',
    NOW () - INTERVAL '11 days'
  ),
  (
    gen_random_uuid (),
    'Angular 19: Что нового?',
    'Обзор последних изменений в рендеринге и гидратации компонентов...',
    'angular-19-whats-new',
    NOW () - INTERVAL '12 days',
    NOW () - INTERVAL '12 days'
  ),
  (
    gen_random_uuid (),
    'Deep Dive: Dependency Injection',
    'Как работает DI в Angular под капотом и зачем нужны InjectionToken...',
    'deep-dive-di',
    NOW () - INTERVAL '13 days',
    NOW () - INTERVAL '13 days'
  ),
  (
    gen_random_uuid (),
    'Оптимизация Docker образов',
    'Как уменьшить размер образа вашего .NET приложения с 800МБ до 100МБ...',
    'docker-image-optimization',
    NOW () - INTERVAL '14 days',
    NOW () - INTERVAL '14 days'
  ),
  (
    gen_random_uuid (),
    'Redis как кэш для Web API',
    'Настройка распределенного кэширования для ускорения отдачи постов...',
    'redis-caching-web-api',
    NOW () - INTERVAL '15 days',
    NOW () - INTERVAL '15 days'
  ),
  (
    gen_random_uuid (),
    'SOLID на практике',
    'Разбираем каждый принцип на примере реального сервиса блога...',
    'solid-principles-practice',
    NOW () - INTERVAL '16 days',
    NOW () - INTERVAL '16 days'
  ),
  (
    gen_random_uuid (),
    'Настройка Serilog',
    'Как писать логи в Elasticsearch и настраивать алертинг...',
    'serilog-setup-guide',
    NOW () - INTERVAL '17 days',
    NOW () - INTERVAL '17 days'
  ),
  (
    gen_random_uuid (),
    'JWT авторизация в деталях',
    'Безопасное хранение токенов, Refresh tokens и механизм ротации...',
    'jwt-auth-details',
    NOW () - INTERVAL '18 days',
    NOW () - INTERVAL '18 days'
  ),
  (
    gen_random_uuid (),
    'Тестирование с Playwright',
    'Автоматизация UI тестов для Angular приложения...',
    'playwright-ui-testing',
    NOW () - INTERVAL '19 days',
    NOW () - INTERVAL '19 days'
  ),
  (
    gen_random_uuid (),
    'CSS Grid vs Flexbox',
    'Когда и что использовать для современной верстки макетов...',
    'grid-vs-flexbox',
    NOW () - INTERVAL '20 days',
    NOW () - INTERVAL '20 days'
  ),
  (
    gen_random_uuid (),
    'Микрофронтенды с Module Federation',
    'Разделение монолита на независимые Angular приложения...',
    'microfrontends-module-federation',
    NOW () - INTERVAL '21 days',
    NOW () - INTERVAL '21 days'
  ),
  (
    gen_random_uuid (),
    'Работа с Reactive Forms',
    'Сложные валидаторы и динамические формы в Angular...',
    'reactive-forms-advanced',
    NOW () - INTERVAL '22 days',
    NOW () - INTERVAL '22 days'
  ),
  (
    gen_random_uuid (),
    'Основы OAuth2',
    'Интеграция входа через Google и GitHub в ваш блог...',
    'oauth2-basics',
    NOW () - INTERVAL '23 days',
    NOW () - INTERVAL '23 days'
  ),
  (
    gen_random_uuid (),
    'GraphQL vs REST',
    'Сравнение подходов к проектированию API в 2024 году...',
    'graphql-vs-rest',
    NOW () - INTERVAL '24 days',
    NOW () - INTERVAL '24 days'
  ),
  (
    gen_random_uuid (),
    'Kubernetes для новичков',
    'Развертывание вашего API в кластер: поды, сервисы, ингрессы...',
    'kubernetes-for-beginners',
    NOW () - INTERVAL '25 days',
    NOW () - INTERVAL '25 days'
  ),
  (
    gen_random_uuid (),
    'Профайлинг .NET приложений',
    'Поиск утечек памяти с помощью dotMemory и dotTrace...',
    'dot-net-profiling',
    NOW () - INTERVAL '26 days',
    NOW () - INTERVAL '26 days'
  ),
  (
    gen_random_uuid (),
    'Zoneless Angular',
    'Будущее без zone.js и как это ускоряет Change Detection...',
    'zoneless-angular-future',
    NOW () - INTERVAL '27 days',
    NOW () - INTERVAL '27 days'
  ),
  (
    gen_random_uuid (),
    'C# Source Generators',
    'Автоматическая генерация кода во время компиляции...',
    'csharp-source-generators',
    NOW () - INTERVAL '28 days',
    NOW () - INTERVAL '28 days'
  ),
  (
    gen_random_uuid (),
    'Gitflow vs Trunk Based Development',
    'Какую стратегию ветвления выбрать для команды...',
    'git-branching-strategies',
    NOW () - INTERVAL '29 days',
    NOW () - INTERVAL '29 days'
  ),
  (
    gen_random_uuid (),
    'SignalR: Real-time обновления',
    'Как сделать уведомления о новых комментариях мгновенными...',
    'signalr-real-time',
    NOW () - INTERVAL '30 days',
    NOW () - INTERVAL '30 days'
  ),
  (
    gen_random_uuid (),
    'Безопасность заголовков HTTP',
    'Настройка CSP, HSTS и X-Frame-Options в ASP.NET Core...',
    'http-security-headers',
    NOW () - INTERVAL '31 days',
    NOW () - INTERVAL '31 days'
  ),
  (
    gen_random_uuid (),
    'SASS Mixins и функции',
    'Ускоряем написание стилей и поддерживаем DRY в CSS...',
    'sass-mixins-dry',
    NOW () - INTERVAL '32 days',
    NOW () - INTERVAL '32 days'
  ),
  (
    gen_random_uuid (),
    'Основы алгоритмов для фронтенд-разработчика',
    'Зачем знать сложность O(n) и как это применять в коде...',
    'algorithms-for-frontend',
    NOW () - INTERVAL '33 days',
    NOW () - INTERVAL '33 days'
  ),
  (
    gen_random_uuid (),
    'Azure Functions и Serverless',
    'Создание легковесных бэкэнд-триггеров без поддержки сервера...',
    'azure-functions-serverless',
    NOW () - INTERVAL '34 days',
    NOW () - INTERVAL '34 days'
  ),
  (
    gen_random_uuid (),
    'Паттерн Репозиторий: За и Против',
    'Стоит ли скрывать DbContext за интерфейсом в 2024 году...',
    'repository-pattern-pros-cons',
    NOW () - INTERVAL '35 days',
    NOW () - INTERVAL '35 days'
  );
