# ��8�� ������Ͳ�����

## 1. һ��������Ĳ���
1. ����������Ϊ����
2. ִ��ĳ������
3. ���ؽ��


## 2. ����Ϊ�������Ľṹ��
1. ������
2. ����
3. ����
4. ��������
5. ������
6. �������ʽ

## 3. ������
���������ڱ���ʱȷ����һ���̶�ֵ��ͨ�������ֻ����ַ���

����������

```C#
236  //����
236L //������
236U //�޷�������
236UL//�޷��ų�����
```
ʵ��������

```C#
float f1=236F;      //�����ȸ�����
double d1=236.712;  //˫���ȸ�����
double d2=.351;     //С����ǰ����ʡ��
double d3=6.338e-26;//��ѧ������
decimal d4=236.712M;//�߾��ȸ�����
```

�ַ�������

�ַ���������������������һ�֣�

1. �����ַ�
2. ��ת�����У���б��+�����ַ�
3. ʮ������ת�����У���б��+��д��Сдx+4��ʮ��������
4. Unicodeת�����У���б��+��д��Сдu+4��ʮ��������

```C#
char c1='d';
char c2='\n';
char c3='\x0061';
char c4='\u005a';
```

�ַ���������

1. �����ַ���������
2. �����ַ��������� ������ת���ַ������Կ��У�����˫���Żᱻ����Ϊһ��˫����

```C#
string rst1="Hi there!";
string vst1=@"Hi there!";
string rst2="It started,\"Four score and seven...\"";
string vst2=@"It started,""Four score and seven...""";
string rst3="Value 1 \t 5,val2 \t 10";
string vst3=@"Value 1 \t 5,val2 \t 10";
string rst4="C:\\Program Files\\Microsoft\\";
string vst4=@"C:\Program Files\Microsoft\";
string rst5=" Print \x000A Multiple \u000A Lines";
string vst5=@" Print
    Multiple
    Lines";
```

## 4. ��ֵ˳��

1. ������
2. ���ȼ�
3. ����

### 4.1 ���ȼ�
1. ������������ȣ�������a.x��f(x)��a[x]��x++��x--��new��typeof��checked��unchecked
2. һԪ����� ����+��-��~��++��--��(T)x
3. �˷������ *��/��%
4. �ӷ������ +��-
5. ��λ����� <<��>>
6. ��ϵ����� <��>��<=��>=��is��as
7. �������� ==��!=
8. �߼������ &��^��|
9. �����߼������ &&��||
10. ��������� ?:
11. ��ֵ����� =��+=��-=��*=��/=��%=��&=��^=��|=��<<=��>>=

## 5. �û����������ת��

### 5.1 ��ʽ����ת��
```C#
       �����                     Ŀ������       Դ����
         ��                          ��           ��
public static implicit operator TargetType(SourceType Identifier)
{
    ...
    return ObjectOfTargetType;
}
```

### 5.2 ��ʽ����ת��
```C#
       �����                     Ŀ������       Դ����
         ��                          ��           ��
public static explicit operator TargetType(SourceType Identifier)
{
    ...
    return ObjectOfTargetType;
}
```

## 6. ���������

��������������㶨��C#�����Ӧ����β����Զ������͵Ĳ�����

1. ���������ֻ��������ͽṹ
2. ��������ͬʱʹ��static��public���η�
3. �����������Ҫ���������ṹ�ĳ�Ա

```C#
     �����        ����     �ؼ��� �����        ������
       ��           ��        ��     ��            ��
public static LimitedInt operator + (LimitedInt x,double y)

public static LimitedInt operator - (LimitedInt x)
```

### 6.1 ���������������

1. �����ص������
	1. �����ص�һԪ�������+��-������~��++��--��true��false
	2. �����صĶ�أ�������+��-��\*��/������&��| �ˡ�<<��>>��\==��!=������������=����=
2. ��������ز��ܣ�
	1. �������������
	2. �ı���������﷨��
	3. ���¶����������δ���Ԥ�������ͣ�
	4. �ı�����������ȼ�����
3. ����������͵ݼ��������ע�����
	1. ������ʱ������Ĵ���Զ���ִ��ǰ�ò���(ǰ�õ�����ǰ�õݼ�)ʱ���ᷢ��������Ϊ: 
		1. �ڶ�����ִ�е�����ݼ����룻
		2. ���ض���
	2. ������ʱ������Ĵ���Զ���ִ�к��ò���(���õ�������õݼ�)ʱ���ᷢ��������Ϊ��
		1. ���������ֵ���ͣ���ϵͳ�Ḵ�Ƹö�������������������ͣ������ûᱻ���ơ�
		2. �ڶ�����ִ�е�����ݼ����롣
		3. ���ر���Ĳ�������

## 7. typeof�����

typeof�����������Ϊ��������κ����͵�System.Type����

eg:ʹ��typeof�������ȡSomeClass�����Ϣ

```C#
using System.Reflection;//����
class SomeClass
{
    public int Field1;
    public int Field2;
    public void Method1(){}
    public int Method2(){return 1;}
}
class Program
{
    static void Main()
    {
        var t=typeof(SomeClass);
        FieldInfo[] fi=t.GetFields();
        MethodInfo[] mi=t.GetMethods();
        foreach(var f in fi)
            Console.WriteLine("Field:{0}",f.Name);
        foreach(var m in mi)
            Console.WriteLine("Method:{0}",m.Name);
    }
}
```

output:

```bash
Field:Field1
Field:Field2
Method:Method1
Method:Method2
Method:ToString
Method:Equals
Method:GetHashCode
Method:GetType
```

ֵ��ע�����`GetFields`��Щ����ֻ���õ��������ֶκͷ�������Դ�����£�

```C#
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)]
public FieldInfo[] GetFields() => GetFields(Type.DefaultLookup);
```