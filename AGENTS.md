## Blog4uSlf — описание для AGENTS

Этот файл предназначен для людей и агентов (AI), которые работают с репозиторием. Здесь собраны:

- **Краткое описание проекта**
- **Текущий стек (frontend, backend, инфраструктура)**
- **Базовые правила и ожидания**
- **Подсказки по запуску и навигации по коду**

---

## 1. Общее описание проекта

- **Назначение**: учебно-пет-проект блога, в котором пользователь может создавать и просматривать посты. Проект разделён на backend (`backend/`) и frontend (`frontend/`).
- **Архитектура backend**: многослойная архитектура на .NET (Domain, Application, Infrastructure, Web, Tests). Clean architecture.
- **Архитектура frontend**: Nx-монорепозиторий с Angular-приложением `blog-4u-slf` и библиотеками в `libs/`, FSD.

---

## 2. Текущий стек

- **Backend**
  - **Платформа**: `.NET` (`net10.0` в `Blog4uSlf.Web.csproj`).
  - **Web-фреймворк**: ASP.NET Core (`Microsoft.NET.Sdk.Web`).
  - **ORM**: `Microsoft.EntityFrameworkCore` + `Npgsql.EntityFrameworkCore.PostgreSQL`.
  - **Валидация**: `FluentValidation.AspNetCore`.
  - **Маппинг**: `Mapster`, `Mapster.DependencyInjection`.
  - **Документация API**: `Swashbuckle.AspNetCore` (+ `Swashbuckle.AspNetCore.Annotations`).
  - **Логирование**: `Serilog`, `Serilog.AspNetCore`, `Serilog.Sinks.File` (логи в `Blog4uSlf.Web/logs/`).

- **Frontend**
  - **Инструмент**: `Nx` (workspace в `frontend/`, основное приложение `apps/blog-4u-slf`).
  - **Фреймворк**: Angular 21 (`@angular/*` 21.x).
  - **Состояние и эффекты**: `@ngrx/effects`, `@ngrx/operators`, `@ngrx/signals`.
  - **UI-kit**: `Taiga UI` (`@taiga-ui/*`, `taiga-ui`).
  - **Язык**: TypeScript 5.9.
  - **Тестирование**: Jest + Cypress (через плагины `@nx/jest`, `@nx/cypress`).
  - **Линтинг/форматирование**: ESLint, Prettier, `angular-eslint`.

- **Инфраструктура и прочее**
  - **База данных**: PostgreSQL (через `Npgsql.EntityFrameworkCore.PostgreSQL`).
  - **Миграции**: EF Core миграции в `backend/Blog4uSlf.Infrastructure/Migrations/`.
  - **Контейнеризация**: `docker/docker-compose.yml` (см. этот файл для актуальной конфигурации сервисов).

---

## 3. Структура репозитория (высокоуровнево)

- **Корень**
  - `backend/` — backend-решение .NET (`Blog4uSlf.sln`, проекты Domain/Application/Infrastructure/Web/Tests).
  - `frontend/` — Nx-монорепо с Angular-приложением и библиотеками.
  - `docker/` — docker-compose и инфраструктурные настройки.

- **Backend**
  - `Blog4uSlf.Domain/` — доменная модель, интерфейсы, enum'ы.
  - `Blog4uSlf.Application/` — application-слой, сервисы, абстракции, бизнес-логика.
  - `Blog4uSlf.Infrastructure/` — EF Core контекст, миграции, реализации репозиториев, конфигурации.
  - `Blog4uSlf.Web/` — ASP.NET Core Web API (контроллеры, DTO, валидация, middleware, настройки OpenAPI, CORS и т.д.).
  - `Blog4uSlf.Tests/` — модульные и интеграционные тесты.

- **Frontend**
  - `apps/blog-4u-slf/` — основное Angular-приложение.
  - `apps/blog-4u-slf-e2e/` — e2e-тесты.
  - `libs/pages/` — переиспользуемые страницы/модули (см. `libs/pages/home`, `libs/pages/posts` и их README).

---

## 4. Запуск проекта (локально)

Общая идея: поднять backend (ASP.NET Core + PostgreSQL, при необходимости через Docker) и frontend (Nx + Angular).

- **Backend**
  - Открыть решение `backend/Blog4uSlf.sln` в IDE (Rider/VS Code/Visual Studio).
  - Убедиться, что настроена БД PostgreSQL (или использовать docker-compose).
  - Запустить проект `Blog4uSlf.Web` (обычно профиль `Development`, конфиги в `appsettings.Development.json`).

- **Frontend**
  - Перейти в `frontend/`.
  - Установить зависимости: `npm install`.
  - Запустить dev-сервер: `npx nx serve blog-4u-slf` (см. также `frontend/README.md`).

Для CI/CD, расширенной конфигурации `Nx` и прочих нюансов см. `frontend/README.md` и документацию Nx.

---

## 5. Правила и договорённости для разработки

- **Стиль и качество кода**
  - **C#**: следовать современным практикам .NET (nullable enable, implicit usings, маленькие и чёткие классы/методы).
  - **TypeScript/Angular**: соблюдать рекомендации Angular и Taiga UI, использовать типизацию без `any`, структурировать приложения через модули/feature-модули.
  - Поддерживать единый стиль форматирования (ESLint + Prettier на frontend, стандартный .NET формат на backend).

- **Архитектура**
  - Соблюдать разделение на слои: Domain ↔ Application ↔ Infrastructure ↔ Web.
  - Не класть бизнес-логику в контроллеры; использовать сервисы в `Application` и репозитории в `Infrastructure`.
  - На frontend избегать «разрастания» компонентов, выносить логику в сервисы, использовать NgRx/Signals там, где это оправдано.

- **Тесты**
  - Для backend — покрывать ключевую бизнес-логику модульными и интеграционными тестами в `Blog4uSlf.Tests`.
  - Для frontend — по мере необходимости добавлять unit-тесты (Jest) и e2e (Cypress).

- **Git и PR**
  - Делать небольшие, осмысленные коммиты с понятными сообщениями на английском.
  - В PR описывать суть изменений, риски и необходимые шаги по развёртыванию/миграциям.

---

## 6. Рекомендации для AI-агентов

Если вы — AI-агент, работающий с этим репозиторием:

- **Всегда**:
  - Учитывайте многослойную архитектуру backend и не нарушайте зависимости между слоями.
  - Согласовывайте новые публичные API-эндпоинты с существующей моделью домена и DTO.
  - На frontend следите за тем, чтобы не ломать маршрутизацию и контракты API.

- **Перед внесением крупных изменений**:
  - Посмотрите существующие аналогичные места (пример сервиса/контроллера/страницы) и следуйте принятым паттернам.
  - Проверяйте наличие миграций и влияния на БД, если меняется модель.

- **После изменений**:
  - Убедитесь, что проект собирается (backend и frontend).
  - При возможности запускайте соответствующие тесты (backend tests, `nx test`, `nx e2e`).

---

## 7. Контакты и будущие планы

- **Контакты**: основной владелец репозитория — `eduard-kopylov` (GitHub/локальный пользователь).
- **Планы развития** (примерно, могут меняться):
  - Доработка функционала постов (поиск, фильтрация, категории, теги).
  - Добавление аутентификации и авторизации.
  - Улучшение UI/UX на базе Taiga UI.
  - Расширение тестового покрытия (включая e2e).

Если вы вносите изменения в архитектуру или стек, пожалуйста, обновите этот файл, чтобы он оставался актуальным.
