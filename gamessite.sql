-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 12 2022 г., 18:55
-- Версия сервера: 5.7.38
-- Версия PHP: 7.3.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `gamessite`
--

-- --------------------------------------------------------

--
-- Структура таблицы `contacts`
--

CREATE TABLE `contacts` (
  `geo` text NOT NULL,
  `tel` text NOT NULL,
  `mail` text NOT NULL,
  `adr` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `contacts`
--

INSERT INTO `contacts` (`geo`, `tel`, `mail`, `adr`) VALUES
('<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1501.6138179618683!2d30.315790315440253!3d59.93742166915964!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4696311001a251a5%3A0xea5aaef84f7e911!2z0JHQvtC70YzRiNCw0Y8g0JzQvtGA0YHQutCw0Y8g0YPQuy4sIDQsINCh0LDQvdC60YIt0J_QtdGC0LXRgNCx0YPRgNCzLCAxOTExODY!5e1!3m2!1sru!2sru!4v1587562970538!5m2!1sru!2sru\" width=\"300\" height=\"350\" frameborder=\"0\" style=\"border:0;\" allowfullscreen=\"\" aria-hidden=\"false\" tabindex=\"0\"></iframe>', '88124567712', 'antoniy1999@mail.ru', 'Большая Морская, 4');

-- --------------------------------------------------------

--
-- Структура таблицы `faqaccess`
--

CREATE TABLE `faqaccess` (
  `question` text NOT NULL,
  `answer` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

--
-- Дамп данных таблицы `faqaccess`
--

INSERT INTO `faqaccess` (`question`, `answer`) VALUES
('Как часто у вас выходят игры?', 'Мы выпускаем мобильные игры примерно раз в пару месяцев. Также обстоят дела с дополнениями.'),
('Нужно ли мне регистрироваться, чтобы играть и скачивать игры?', 'Аккаунт вам нужен только для того, чтобы иметь возможность общаться на нашем <a href=\"http://5_version_1/Forum.php\">форуме</a>.');

-- --------------------------------------------------------

--
-- Структура таблицы `faqcommunity`
--

CREATE TABLE `faqcommunity` (
  `question` text NOT NULL,
  `answer` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `faqcommunity`
--

INSERT INTO `faqcommunity` (`question`, `answer`) VALUES
('Как я могу стать частью вашего игрового комьюнити?', 'Для этого достаточно посетить наши страницы на <a href=\"http://5_version_1/Forum.php\">Фейсбук</a>, <a href=\"http://5_version_1/Forum.php\">Инстаграм</a> и также заглянуть на наш <a href=\"http://5_version_1/Forum.php\">официальный форум</a>.'),
('Я утубер или стример и я хочу делать контент по вашим играм - как с вами связаться?', 'Посетите нашу <a href=\"http://5_version_1/Contacts.php\">контактную страницу</a> и оставьте вашу заявку. Также можете связаться с нами через <a href=\"http://5_version_1/Contacts.php\">Дискорд</a>');

-- --------------------------------------------------------

--
-- Структура таблицы `faqhelp`
--

CREATE TABLE `faqhelp` (
  `question` text NOT NULL,
  `answer` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `faqhelp`
--

INSERT INTO `faqhelp` (`question`, `answer`) VALUES
('Как мне рассказать о баге? У меня технические проблемы - как получить помощь?', 'Если у вас есть сведения о технических проблемах/багах в одной из игр, вам нужно написать на нашу техническую почту через удобное окошко в начале этой страницы.'),
('Какова ваша политика в отношении \"патчей\" для игр?', 'У нас нет специфичной политики в исправлении проблем уже выпущенных игр, так как мы это делаем параллельно выпуская новые игры.');

-- --------------------------------------------------------

--
-- Структура таблицы `games`
--

CREATE TABLE `games` (
  `nomer` int(11) NOT NULL,
  `Name` text NOT NULL,
  `gif` text NOT NULL,
  `link` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `games`
--

INSERT INTO `games` (`nomer`, `Name`, `gif`, `link`) VALUES
(1, 'Amazing Racer', '3.gif', 'http://Version/Game_Page3.php'),
(2, 'Meteor Destroyer ', '2.gif', 'http://Version/Game_Page2.php'),
(3, 'RunToLive', '1.gif', 'http://Version/Game_Page1.php');

-- --------------------------------------------------------

--
-- Структура таблицы `news`
--

CREATE TABLE `news` (
  `nomer` int(11) NOT NULL,
  `name` text NOT NULL,
  `plot` text NOT NULL,
  `data` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `news`
--

INSERT INTO `news` (`nomer`, `name`, `plot`, `data`) VALUES
(1, 'Дневник разработчиков 1', 'Сегодня мы выпустили нашу первую игру в мобильном формате. Amazing Racer - пробуйте и играйте.', '23:00 - 09.06.2021'),
(2, 'Дневник # 2', 'Патч-ноут : \r\n1) Исправили баги с диско-шарами . их неправильным отображением.\r\n2) Корректный подсчет очков с учетом красных плит.', '10.06.2021'),
(3, 'Дневник # 3', 'Финальное тестирование сайта', '11.09.2021');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `games`
--
ALTER TABLE `games`
  ADD PRIMARY KEY (`nomer`);

--
-- Индексы таблицы `news`
--
ALTER TABLE `news`
  ADD PRIMARY KEY (`nomer`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `games`
--
ALTER TABLE `games`
  MODIFY `nomer` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `news`
--
ALTER TABLE `news`
  MODIFY `nomer` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
