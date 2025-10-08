﻿SELECT 
	stud_id,
	FORMATMESSAGE(N'%s %s %s',last_name,first_name,middle_name) AS N'Студент',
	group_name AS N'Группа',
	direction_name AS N'Направление'
FROM Students,Groups,Directions 
WHERE [group]=group_name AND direction=direction_name;