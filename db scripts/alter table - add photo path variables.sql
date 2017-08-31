alter table [dbo].[BlogPostsTable]
add [PostPhotoStr] varchar(100) NULL,
	[PostPhoto30_30Str] varchar(100) NULL,
	[PostPhoto160_160Str] varchar(100) NULL


select count(*) from BlogPostsTable
where PostPhoto is not null


E:\Develop\Atlas\AtlasForms\AtlasForms3\AtlasForms3\Content\postimages\082017



update BlogPostsTable
set PostPhotoStr = '/Content/postimages/082017/' + convert(varchar, Id)+ '.png',
	PostPhoto30_30Str = '/Content/postimages/082017/' + convert(varchar, Id) + '.png',
	PostPhoto160_160Str = '/Content/postimages/082017/' + convert(varchar, Id) + '.png'
where PostPhoto is not null


select * from BlogPostsTable
where PostPhoto is not null
