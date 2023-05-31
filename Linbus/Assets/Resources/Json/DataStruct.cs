
public struct Enemy
{
    public string Name; //적의 이름
    public int Hp; //적의 hp
    public int AttTower; //타워를 공격할 시 들어가는 데미지
    public int AttCastle; //성에 들어갈 시 들어가는 데미지
    public int DmgResist; //피해저항
    public string Rarity; //적의 레어도 : Basic, Nomal, Boss
    public bool Tag; //적의 태그 : 광역(true), 단일(false)
    public string info; //적에 대한 설명 : ex)기본적인 적이다, 다른 유닛보다 빠르다 등...
    public int AttRangeX; //적 스킬 X 범위
    public int AttRangeZ; //적 스킬 Z 범위
    public int AttObj; //적의 공격 물체 : 1(화살), 2(마법), 3(창), 4(단검),5(흑마술), 6(거미줄)
    public int AttSpeed; //적 공격 속도
    public int Cooldown; //적 스킬 쿨타임
    public string SkillInfo; //적 스킬 정보
    public int SkillRange; //적 스킬 범위
    public int SkillAtt; //스킬 공격력
    public int Speed; //적의 이동 속도
    public string ImgPath; //적의 이미지 경로

    public Enemy(string Name, int Hp, int AttTower, int AttCastle, int DmgResist, bool Tag, string Rarity, string info, int AttRangeX, int AttRangeZ, int AttObj, int Cooldown, string SkillInfo, int SkillAtt, int SkillRange, int Speed, int AttSpeed, string ImgPath)
    {
        this.Name = Name;
        this.Hp = Hp;
        this.AttTower = AttTower;
        this.AttCastle = AttCastle;
        this.DmgResist = DmgResist;
        this.Tag = Tag;
        this.Rarity = Rarity;
        this.info = info;
        this.AttRangeX = AttRangeX;
        this.AttRangeZ = AttRangeZ;
        this.AttObj = AttObj;
        this.AttSpeed = AttSpeed;
        this.Cooldown = Cooldown;
        this.SkillInfo = SkillInfo;
        this.SkillRange = SkillRange;
        this.Speed = Speed;
        this.SkillAtt = SkillAtt;
        this.ImgPath = ImgPath;
    }
}


public struct Tower
{
    public string Name; //타워 이름
    public int Hp; //타워의 hp
    public int Att; //타워의 공격력
    public int DmgResist; //피해저항
    public string Rarity; //타워의 레어도 : Nomal, Rare, Super Rare, Ultra Rare
    public bool Tag; //타워의 태그 : 광역, 단일
    public string Skill; //타워의 스킬 : 회복, 저주, 속박, 은신...
    public string Info; //타워의 정보: ex) 이 용병이 전장에 있을 시, 적들이 우선으로 공격합니다.
    public int AttRangeX; //타워의 공격 범위
    public int AttRangeZ; //타워의 공격 범위
    public int AttObj; //타워의 공격 물체 : ex) 화살, 마법...
    public int AttSpeed; //타워 공격 속도
    public int Cooldown; //타워 스킬 쿨타임
    public int SkillRangeX; //적 스킬 X 범위
    public int SkillRangeZ; //적 스킬 Z 범위
    public int SkillAtt; //타워 스킬 공격력
    public string SkillInfo; //타워 스킬 설명
    public string ImgPath; //타워 이미지 경로

    public Tower(string Name, int Hp, int Att, int DmgResist, string Rarity, bool Tag, string Skill, string Info, int AttRangeX, int AttRangeZ, int AttObj, int AttSpeed, int Cooldown, int SkillRangeX, int SkillRangeZ, int SkillAtt, string SkillInfo, string ImgPath)
    {
        this.Name = Name;
        this.Hp = Hp;
        this.Att = Att;
        this.DmgResist = DmgResist;
        this.Rarity = Rarity;
        this.Tag = Tag;
        this.Skill = Skill;
        this.Info = Info;
        this.AttRangeX = AttRangeX;
        this.AttRangeZ = AttRangeZ;
        this.AttObj = AttObj;
        this.AttSpeed = AttSpeed;
        this.Cooldown = Cooldown;
        this.SkillRangeZ = SkillRangeZ;
        this.SkillRangeX = SkillRangeX;
        this.SkillAtt = SkillAtt;
        this.SkillInfo = SkillInfo;
        this.ImgPath = ImgPath;
    }
}


public struct Support
{
    public string Name; //지원카드의 이름
    public string Info; //지원카드의 설명 : ex) 성을 수리해, 성이 5hp를 회복합니다.
    public int AttRange; //지원카드 공격범위
    public int Att; //지원카드 공격력
    public string ImgPath; //지원카드 이미지 경로

    public Support(string Nmae, string Info, int AttRange, int Att, string ImgPath)
    {
        this.Name = Nmae;
        this.Info = Info;
        this.AttRange = AttRange;
        this.Att = Att;
        this.ImgPath = ImgPath;
    }
}

public struct UserInfo
{
    public string Id; //유저 id
    public string Pwd; //유저 비밀번호
    public string Name; //유저 닉네임
    public string Info; //유저 자기소개
    public string[] HaveTower; //보유 타워
    public string[] HaveSupport; //보유 지원카드


    public UserInfo(string Id, string Pwd, string Name, string Info, string[] HaveTower, string[] HaveSupport)
    {
        this.Id = Id;
        this.Pwd = Pwd;
        this.Name = Name;
        this.Info = Info;
        this.HaveTower = HaveTower;
        this.HaveSupport = HaveSupport;
    }

}