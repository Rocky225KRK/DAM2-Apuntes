> ! Recorda de posar la classe al Database entities: <NomClasse>.class

# Inici classe model de la BD
@Entity(tableName = "monster")
public class Monster {

# Inici classe model de la BD si té claus foranes
@Entity(
    tableName = "monster",
    foreignKeys = @ForeignKey(entity = Category.class,
    parentColumns = "id",
    childColumns = "category_id"))
public class Monster {

# Clau primaria
@PrimaryKey()
@NonNull()
private String id;

# ID autogenerada
@PrimaryKey(autoGenerate = true)
public int id;

# Columna normal
@ColumnInfo(name = "name")
public String name;