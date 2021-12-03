using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using avanadeLearning_webApi.Domains;

#nullable disable

namespace avanadeLearning_webApi.Contexts
{
    public partial class AvanadeLearningContext : DbContext
    {
        public AvanadeLearningContext()
        {
        }

        public AvanadeLearningContext(DbContextOptions<AvanadeLearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arquetipo> Arquetipos { get; set; }
        public virtual DbSet<ArquivoModulo> ArquivoModulos { get; set; }
        public virtual DbSet<ArquivoPostagem> ArquivoPostagems { get; set; }
        public virtual DbSet<Aula> Aulas { get; set; }
        public virtual DbSet<AulaModulo> AulaModulos { get; set; }
        public virtual DbSet<AulaQuesto> AulaQuestoes { get; set; }
        public virtual DbSet<AulasVistum> AulasVista { get; set; }
        public virtual DbSet<CategoriaCurso> CategoriaCursos { get; set; }
        public virtual DbSet<CategoriaQuestao> CategoriaQuestaos { get; set; }
        public virtual DbSet<CategoriasCurso> CategoriasCursos { get; set; }
        public virtual DbSet<CategoriasQuestao> CategoriasQuestaos { get; set; }
        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<ConquistaUsuario> ConquistaUsuarios { get; set; }
        public virtual DbSet<Conquistum> Conquista { get; set; }
        public virtual DbSet<Cursando> Cursandos { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<EstadoUsuario> EstadoUsuarios { get; set; }
        public virtual DbSet<Instituicao> Instituicaos { get; set; }
        public virtual DbSet<LikeComentario> LikeComentarios { get; set; }
        public virtual DbSet<LikePostagem> LikePostagems { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Postagem> Postagems { get; set; }
        public virtual DbSet<Questao> Questaos { get; set; }
        public virtual DbSet<QuestaoFeitum> QuestaoFeita { get; set; }
        public virtual DbSet<RedeSocial> RedeSocials { get; set; }
        public virtual DbSet<RedesUsuario> RedesUsuarios { get; set; }
        public virtual DbSet<Respostum> Resposta { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioArquetipo> UsuarioArquetipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=avanadeLearning; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Arquetipo>(entity =>
            {
                entity.HasKey(e => e.IdArquetipo)
                    .HasName("PK__arquetip__669565E1C30D2D9A");

                entity.ToTable("arquetipo");

                entity.HasIndex(e => e.Nome, "UQ__arquetip__6F71C0DC217F8A7C")
                    .IsUnique();

                entity.Property(e => e.IdArquetipo).HasColumnName("idArquetipo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<ArquivoModulo>(entity =>
            {
                entity.HasKey(e => e.IdArquivoModulo)
                    .HasName("PK__arquivoM__3401AB9BF76AC891");

                entity.ToTable("arquivoModulo");

                entity.Property(e => e.IdArquivoModulo).HasColumnName("idArquivoModulo");

                entity.Property(e => e.Arquivo)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("arquivo");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.ArquivoModulos)
                    .HasForeignKey(d => d.IdModulo)
                    .HasConstraintName("FK__arquivoMo__idMod__5DCAEF64");
            });

            modelBuilder.Entity<ArquivoPostagem>(entity =>
            {
                entity.HasKey(e => e.IdArquivoPostagem)
                    .HasName("PK__arquivoP__6DEA034B3DB8AC82");

                entity.ToTable("arquivoPostagem");

                entity.Property(e => e.IdArquivoPostagem).HasColumnName("idArquivoPostagem");

                entity.Property(e => e.Arquivo)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("arquivo");

                entity.Property(e => e.IdPostagem).HasColumnName("idPostagem");

                entity.HasOne(d => d.IdPostagemNavigation)
                    .WithMany(p => p.ArquivoPostagems)
                    .HasForeignKey(d => d.IdPostagem)
                    .HasConstraintName("FK__arquivoPo__idPos__5441852A");
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.HasKey(e => e.IdAula)
                    .HasName("PK__aula__D861CCCB422EDAA4");

                entity.ToTable("aula");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.LinkConteudoExtra)
                    .IsUnicode(false)
                    .HasColumnName("linkConteudoExtra");

                entity.Property(e => e.Video)
                    .IsUnicode(false)
                    .HasColumnName("video");
            });

            modelBuilder.Entity<AulaModulo>(entity =>
            {
                entity.HasKey(e => e.IdAulaModulo)
                    .HasName("PK__aulaModu__3B864C4E6E223F58");

                entity.ToTable("aulaModulo");

                entity.Property(e => e.IdAulaModulo).HasColumnName("idAulaModulo");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.AulaModulos)
                    .HasForeignKey(d => d.IdAula)
                    .HasConstraintName("FK__aulaModul__idAul__628FA481");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.AulaModulos)
                    .HasForeignKey(d => d.IdModulo)
                    .HasConstraintName("FK__aulaModul__idMod__6383C8BA");
            });

            modelBuilder.Entity<AulaQuesto>(entity =>
            {
                entity.HasKey(e => e.IdAulaQuestoes)
                    .HasName("PK__aulaQues__DCB4D7711165173D");

                entity.ToTable("aulaQuestoes");

                entity.Property(e => e.IdAulaQuestoes).HasColumnName("idAulaQuestoes");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.IdQuestao).HasColumnName("idQuestao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.AulaQuestos)
                    .HasForeignKey(d => d.IdAula)
                    .HasConstraintName("FK__aulaQuest__idAul__6E01572D");

                entity.HasOne(d => d.IdQuestaoNavigation)
                    .WithMany(p => p.AulaQuestos)
                    .HasForeignKey(d => d.IdQuestao)
                    .HasConstraintName("FK__aulaQuest__idQue__6C190EBB");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AulaQuestos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__aulaQuest__idUsu__6D0D32F4");
            });

            modelBuilder.Entity<AulasVistum>(entity =>
            {
                entity.HasKey(e => e.IdAulasVista)
                    .HasName("PK__aulasVis__CA9D44F5EF3F167A");

                entity.ToTable("aulasVista");

                entity.Property(e => e.IdAulasVista).HasColumnName("idAulasVista");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Pontos).HasColumnName("pontos");

                entity.Property(e => e.Visto).HasColumnName("visto");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.AulasVista)
                    .HasForeignKey(d => d.IdAula)
                    .HasConstraintName("FK__aulasVist__idAul__66603565");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AulasVista)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__aulasVist__idUsu__6754599E");
            });

            modelBuilder.Entity<CategoriaCurso>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaCurso)
                    .HasName("PK__categori__A696C38BBA77A248");

                entity.ToTable("categoriaCurso");

                entity.HasIndex(e => e.Categoria, "UQ__categori__1179412F99A433FB")
                    .IsUnique();

                entity.Property(e => e.IdCategoriaCurso).HasColumnName("idCategoriaCurso");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("categoria");
            });

            modelBuilder.Entity<CategoriaQuestao>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaQuestao)
                    .HasName("PK__categori__E6CD759A721AF735");

                entity.ToTable("categoriaQuestao");

                entity.Property(e => e.IdCategoriaQuestao).HasColumnName("idCategoriaQuestao");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<CategoriasCurso>(entity =>
            {
                entity.HasKey(e => e.IdCategoriasCurso)
                    .HasName("PK__categori__108477B8FD15EBB1");

                entity.ToTable("categoriasCurso");

                entity.Property(e => e.IdCategoriasCurso).HasColumnName("idCategoriasCurso");

                entity.Property(e => e.IdCategoriaCurso).HasColumnName("idCategoriaCurso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.HasOne(d => d.IdCategoriaCursoNavigation)
                    .WithMany(p => p.CategoriasCursos)
                    .HasForeignKey(d => d.IdCategoriaCurso)
                    .HasConstraintName("FK__categoria__idCat__49C3F6B7");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CategoriasCursos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__categoria__idCur__48CFD27E");
            });

            modelBuilder.Entity<CategoriasQuestao>(entity =>
            {
                entity.HasKey(e => e.IdCategoriasQuestao)
                    .HasName("PK__categori__3182ECE1A2AA7A20");

                entity.ToTable("categoriasQuestao");

                entity.Property(e => e.IdCategoriasQuestao).HasColumnName("idCategoriasQuestao");

                entity.Property(e => e.IdCategoriaQuestao).HasColumnName("idCategoriaQuestao");

                entity.Property(e => e.IdQuestao).HasColumnName("idQuestao");

                entity.HasOne(d => d.IdCategoriaQuestaoNavigation)
                    .WithMany(p => p.CategoriasQuestaos)
                    .HasForeignKey(d => d.IdCategoriaQuestao)
                    .HasConstraintName("FK__categoria__idCat__72C60C4A");

                entity.HasOne(d => d.IdQuestaoNavigation)
                    .WithMany(p => p.CategoriasQuestaos)
                    .HasForeignKey(d => d.IdQuestao)
                    .HasConstraintName("FK__categoria__idQue__73BA3083");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PK__comentar__C74515DAC6FF9375");

                entity.ToTable("comentario");

                entity.Property(e => e.IdComentario).HasColumnName("idComentario");

                entity.Property(e => e.Comentario1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("comentario");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdAula)
                    .HasConstraintName("FK__comentari__idAul__778AC167");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__comentari__idUsu__76969D2E");
            });

            modelBuilder.Entity<ConquistaUsuario>(entity =>
            {
                entity.HasKey(e => e.IdConquistaUsuario)
                    .HasName("PK__conquist__A16BA0CBFF8C8A7C");

                entity.ToTable("conquistaUsuario");

                entity.Property(e => e.IdConquistaUsuario).HasColumnName("idConquistaUsuario");

                entity.Property(e => e.IdConquista).HasColumnName("idConquista");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdConquistaNavigation)
                    .WithMany(p => p.ConquistaUsuarios)
                    .HasForeignKey(d => d.IdConquista)
                    .HasConstraintName("FK__conquista__idCon__08B54D69");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ConquistaUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__conquista__idUsu__09A971A2");
            });

            modelBuilder.Entity<Conquistum>(entity =>
            {
                entity.HasKey(e => e.IdConquista)
                    .HasName("PK__conquist__6830F5787422AFDB");

                entity.ToTable("conquista");

                entity.Property(e => e.IdConquista).HasColumnName("idConquista");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.Property(e => e.Imagem)
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Pontos).HasColumnName("pontos");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Conquista)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__conquista__idCur__05D8E0BE");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Conquista)
                    .HasForeignKey(d => d.IdModulo)
                    .HasConstraintName("FK__conquista__idMod__04E4BC85");
            });

            modelBuilder.Entity<Cursando>(entity =>
            {
                entity.HasKey(e => e.IdCursando)
                    .HasName("PK__cursando__9FA02B19DA651ECC");

                entity.ToTable("cursando");

                entity.Property(e => e.IdCursando).HasColumnName("idCursando");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Cursandos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__cursando__idCurs__4D94879B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cursandos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__cursando__idUsua__4CA06362");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__curso__8551ED056C2AC82E");

                entity.ToTable("curso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Horas).HasColumnName("horas");

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.Imagem)
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__curso__idInstitu__45F365D3");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__estado__62EA894AD68911B0");

                entity.ToTable("estado");

                entity.HasIndex(e => e.Nome, "UQ__estado__6F71C0DC1D10EEB8")
                    .IsUnique();

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdPais).HasColumnName("idPais");

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Estados)
                    .HasForeignKey(d => d.IdPais)
                    .HasConstraintName("FK__estado__idPais__2F10007B");
            });

            modelBuilder.Entity<EstadoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdEstadoUsuario)
                    .HasName("PK__estadoUs__57088573F70FC6F1");

                entity.ToTable("estadoUsuario");

                entity.Property(e => e.IdEstadoUsuario).HasColumnName("idEstadoUsuario");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.EstadoUsuarios)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__estadoUsu__idEst__3C69FB99");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.EstadoUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__estadoUsu__idUsu__3D5E1FD2");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__institui__8EA7AB000DD62B5A");

                entity.ToTable("instituicao");

                entity.HasIndex(e => e.Cnpj, "UQ__institui__35BD3E48B38F4D5E")
                    .IsUnique();

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<LikeComentario>(entity =>
            {
                entity.HasKey(e => e.IdLikeComentario)
                    .HasName("PK__likeCome__1472B467EAD2C698");

                entity.ToTable("likeComentario");

                entity.Property(e => e.IdLikeComentario).HasColumnName("idLikeComentario");

                entity.Property(e => e.IdComentario).HasColumnName("idComentario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Like).HasColumnName("like");

                entity.HasOne(d => d.IdComentarioNavigation)
                    .WithMany(p => p.LikeComentarios)
                    .HasForeignKey(d => d.IdComentario)
                    .HasConstraintName("FK__likeComen__idCom__7B5B524B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.LikeComentarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__likeComen__idUsu__7A672E12");
            });

            modelBuilder.Entity<LikePostagem>(entity =>
            {
                entity.HasKey(e => e.IdLikePostagem)
                    .HasName("PK__likePost__A2D009266F901C56");

                entity.ToTable("likePostagem");

                entity.Property(e => e.IdLikePostagem).HasColumnName("idLikePostagem");

                entity.Property(e => e.IdPostagem).HasColumnName("idPostagem");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Like).HasColumnName("like");

                entity.HasOne(d => d.IdPostagemNavigation)
                    .WithMany(p => p.LikePostagems)
                    .HasForeignKey(d => d.IdPostagem)
                    .HasConstraintName("FK__likePosta__idPos__571DF1D5");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.LikePostagems)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__likePosta__idUsu__5812160E");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("PK__modulo__3CE613FA8860CBD6");

                entity.ToTable("modulo");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Texto)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("texto");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Modulos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__modulo__idCurso__5AEE82B9");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.IdPais)
                    .HasName("PK__pais__BD2285E333A2775D");

                entity.ToTable("pais");

                entity.HasIndex(e => e.Nome, "UQ__pais__6F71C0DCB38655BC")
                    .IsUnique();

                entity.Property(e => e.IdPais).HasColumnName("idPais");

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Postagem>(entity =>
            {
                entity.HasKey(e => e.IdPostagem)
                    .HasName("PK__postagem__C4F315C6F4E1D5E2");

                entity.ToTable("postagem");

                entity.Property(e => e.IdPostagem).HasColumnName("idPostagem");

                entity.Property(e => e.DataPostagem)
                    .HasColumnType("date")
                    .HasColumnName("dataPostagem");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Texto)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("texto");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Postagems)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__postagem__idCurs__5165187F");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Postagems)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__postagem__idUsua__5070F446");
            });

            modelBuilder.Entity<Questao>(entity =>
            {
                entity.HasKey(e => e.IdQuestao)
                    .HasName("PK__questao__BB81A06586C3EB60");

                entity.ToTable("questao");

                entity.Property(e => e.IdQuestao).HasColumnName("idQuestao");

                entity.Property(e => e.Pergunta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("pergunta");

                entity.Property(e => e.PontosNota).HasColumnName("pontosNota");
            });

            modelBuilder.Entity<QuestaoFeitum>(entity =>
            {
                entity.HasKey(e => e.IdQuestaoFeita)
                    .HasName("PK__questaoF__85C3F477A46F2E56");

                entity.ToTable("questaoFeita");

                entity.Property(e => e.IdQuestaoFeita).HasColumnName("idQuestaoFeita");

                entity.Property(e => e.Feito).HasColumnName("feito");

                entity.Property(e => e.IdAulaQuestoes).HasColumnName("idAulaQuestoes");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Pontos).HasColumnName("pontos");

                entity.HasOne(d => d.IdAulaQuestoesNavigation)
                    .WithMany(p => p.QuestaoFeita)
                    .HasForeignKey(d => d.IdAulaQuestoes)
                    .HasConstraintName("FK__questaoFe__idAul__7E37BEF6");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.QuestaoFeita)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__questaoFe__idUsu__7F2BE32F");
            });

            modelBuilder.Entity<RedeSocial>(entity =>
            {
                entity.HasKey(e => e.IdRedeSocial)
                    .HasName("PK__redeSoci__D35325490917393A");

                entity.ToTable("redeSocial");

                entity.HasIndex(e => e.Nome, "UQ__redeSoci__6F71C0DCB248471E")
                    .IsUnique();

                entity.HasIndex(e => e.LinkBase, "UQ__redeSoci__859BF4BD44F883EF")
                    .IsUnique();

                entity.Property(e => e.IdRedeSocial).HasColumnName("idRedeSocial");

                entity.Property(e => e.LinkBase)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("linkBase");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<RedesUsuario>(entity =>
            {
                entity.HasKey(e => e.IdRedesUsuario)
                    .HasName("PK__redesUsu__5ADA4844C93B3D89");

                entity.ToTable("redesUsuario");

                entity.Property(e => e.IdRedesUsuario).HasColumnName("idRedesUsuario");

                entity.Property(e => e.IdRedeSocial).HasColumnName("idRedeSocial");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.HasOne(d => d.IdRedeSocialNavigation)
                    .WithMany(p => p.RedesUsuarios)
                    .HasForeignKey(d => d.IdRedeSocial)
                    .HasConstraintName("FK__redesUsua__idRed__38996AB5");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RedesUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__redesUsua__idUsu__398D8EEE");
            });

            modelBuilder.Entity<Respostum>(entity =>
            {
                entity.HasKey(e => e.IdResposta)
                    .HasName("PK__resposta__E83D107B7A5B9AC7");

                entity.ToTable("resposta");

                entity.Property(e => e.IdResposta).HasColumnName("idResposta");

                entity.Property(e => e.Correta).HasColumnName("correta");

                entity.Property(e => e.IdQuestao).HasColumnName("idQuestao");

                entity.Property(e => e.Resposta)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("resposta");

                entity.HasOne(d => d.IdQuestaoNavigation)
                    .WithMany(p => p.Resposta)
                    .HasForeignKey(d => d.IdQuestao)
                    .HasConstraintName("FK__resposta__idQues__02084FDA");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF63822DF7");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.Tipo, "UQ__tipoUsua__E7F95649E9C146A8")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A623A183A0");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E6164047259FE")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cargo");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("empresa");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Imagem)
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.ImagemBackground)
                    .IsUnicode(false)
                    .HasColumnName("imagemBackground");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Pontos).HasColumnName("pontos");

                entity.Property(e => e.PontosSemanais).HasColumnName("pontosSemanais");

                entity.Property(e => e.Rg)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("rg");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.SobreMim)
                    .IsUnicode(false)
                    .HasColumnName("sobreMim");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__35BCFE0A");
            });

            modelBuilder.Entity<UsuarioArquetipo>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioArquetipo)
                    .HasName("PK__usuarioA__E7AE58E21CE46ECF");

                entity.ToTable("usuarioArquetipo");

                entity.Property(e => e.IdUsuarioArquetipo).HasColumnName("idUsuarioArquetipo");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.IdArquetipo).HasColumnName("idArquetipo");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Porcentagem).HasColumnName("porcentagem");

                entity.HasOne(d => d.IdArquetipoNavigation)
                    .WithMany(p => p.UsuarioArquetipos)
                    .HasForeignKey(d => d.IdArquetipo)
                    .HasConstraintName("FK__usuarioAr__idArq__0C85DE4D");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioArquetipos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__usuarioAr__idUsu__0D7A0286");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
