import random
from datetime import datetime, timedelta
import configparser
import os
import sys
import string

# 设置标准输出编码为UTF-8
sys.stdout.reconfigure(encoding='utf-8')

# 英文用户名用字（用于邮箱前缀）
english_names = ['alice', 'bob', 'charlie', 'david', 'emma', 'frank', 'grace', 'henry', 'ivy', 'jack',
                'karen', 'leo', 'mia', 'nathan', 'olivia', 'peter', 'quinn', 'rachel', 'steven', 'tina',
                'umar', 'victor', 'wendy', 'xavier', 'yara', 'zack', 'amy', 'brian', 'cathy', 'daniel',
                'eva', 'felix', 'gina', 'harry', 'irene', 'jason', 'kelly', 'lucas', 'monica', 'nick',
                'anna', 'bruce', 'claire', 'derek', 'elsa', 'fred', 'gwen', 'howard', 'iris', 'justin',
                'kate', 'larry', 'melissa', 'nina', 'oscar', 'paul', 'queen', 'ryan', 'sara', 'tom',
                'una', 'vincent', 'wanda', 'xander', 'yasmine', 'zoe', 'adam', 'bella', 'connor', 'daisy']

# 检查并导入MySQL连接器
try:
    import mysql.connector
    mysql_available = True
except ImportError:
    print("警告: 未安装mysql-connector-python库，将生成SQL文件而不是直接插入数据库")
    mysql_available = False

# 打印当前工作目录
print(f"当前工作目录: {os.getcwd()}")

# 检查配置文件是否存在
config_file = 'dbconfig.ini'
db_config = None
if not os.path.exists(config_file):
    print(f"配置文件 {config_file} 不存在，使用默认配置")
    # 使用默认配置
    db_config = {
        'host': 'localhost',
        'user': 'root',
        'password': '123',
        'database': 'student_grade_db'
    }
else:
    # 读取数据库配置
    config = configparser.ConfigParser()
    config.read('dbconfig.ini')
    
    # 数据库连接配置
    db_config = {
        'host': config.get('DEFAULT', 'server', fallback='localhost') if config.has_section('DEFAULT') else config.get('server', 'localhost'),
        'user': config.get('DEFAULT', 'user', fallback='root') if config.has_section('DEFAULT') else config.get('user', 'root'),
        'password': config.get('DEFAULT', 'password', fallback='123') if config.has_section('DEFAULT') else config.get('password', '123'),
        'database': config.get('DEFAULT', 'database', fallback='student_grade_db') if config.has_section('DEFAULT') else config.get('database', 'student_grade_db')
    }

print(f"数据库配置: {db_config}")

# 中文姓名用字
surnames = ['赵', '钱', '孙', '李', '周', '吴', '郑', '王', '冯', '陈', '褚', '卫', '蒋', '沈', '韩', '杨', 
           '朱', '秦', '尤', '许', '何', '吕', '施', '张', '孔', '曹', '严', '华', '金', '魏', '陶', '姜',
           '戚', '谢', '邹', '喻', '柏', '水', '窦', '章', '云', '苏', '潘', '葛', '奚', '范', '彭', '郎',
           '鲁', '韦', '昌', '马', '苗', '凤', '花', '方', '俞', '任', '袁', '柳', '酆', '鲍', '史', '唐',
           '费', '廉', '岑', '薛', '雷', '贺', '倪', '汤', '滕', '殷', '罗', '毕', '郝', '邬', '安', '常',
           '乐', '于', '时', '傅', '皮', '卞', '齐', '康', '伍', '余', '元', '卜', '顾', '孟', '平', '黄',
           '和', '穆', '萧', '尹', '姚', '邵', '湛', '汪', '祁', '毛', '禹', '狄', '米', '贝', '明', '臧',
           '计', '伏', '成', '戴', '谈', '宋', '茅', '庞', '熊', '纪', '舒', '屈', '项', '祝', '董', '梁',
           '杜', '阮', '蓝', '闵', '席', '季', '麻', '强', '贾', '路', '娄', '危', '江', '童', '颜', '郭',
           '梅', '盛', '林', '刁', '钟', '徐', '邱', '骆', '高', '夏', '蔡', '田', '樊', '胡', '凌', '霍',
           '虞', '万', '支', '柯', '昝', '管', '卢', '莫', '经', '房', '裘', '缪', '干', '解', '应', '宗',
           '丁', '宣', '贲', '邓', '郁', '单', '杭', '洪', '包', '诸', '左', '石', '崔', '吉', '钮', '龚',
           '程', '嵇', '邢', '滑', '裴', '陆', '荣', '翁', '荀', '羊', '於', '惠', '甄', '麹', '家', '封',
           '芮', '羿', '储', '靳', '汲', '邴', '糜', '松', '井', '段', '富', '巫', '乌', '焦', '巴', '弓',
           '牧', '隗', '山', '谷', '车', '侯', '宓', '蓬', '全', '郗', '班', '仰', '秋', '仲', '伊', '宫',
           '宁', '仇', '栾', '暴', '甘', '钭', '厉', '戎', '祖', '武', '符', '刘', '景', '詹', '束', '龙',
           '叶', '幸', '司', '韶', '郜', '黎', '蓟', '薄', '印', '宿', '白', '怀', '蒲', '邰', '从', '鄂',
           '索', '咸', '籍', '赖', '卓', '蔺', '屠', '蒙', '池', '乔', '阴', '郁', '胥', '能', '苍', '双',
           '闻', '莘', '党', '翟', '谭', '贡', '劳', '逄', '姬', '申', '扶', '堵', '冉', '宰', '郦', '雍',
           '郤', '璩', '桑', '桂', '濮', '牛', '寿', '通', '边', '扈', '燕', '冀', '郏', '浦', '尚', '农',
           '温', '别', '庄', '晏', '柴', '瞿', '阎', '充', '慕', '连', '茹', '习', '宦', '艾', '鱼', '容',
           '向', '古', '易', '慎', '戈', '廖', '庾', '终', '暨', '居', '衡', '步', '都', '耿', '满', '弘',
           '匡', '国', '文', '寇', '广', '禄', '阙', '东', '欧', '殳', '沃', '利', '蔚', '越', '夔', '隆',
           '师', '巩', '厍', '聂', '晁', '勾', '敖', '融', '冷', '訾', '辛', '阚', '那', '简', '饶', '空',
           '曾', '毋', '沙', '乜', '养', '鞠', '须', '丰', '巢', '关', '蒯', '相', '查', '后', '荆', '红',
           '游', '竺', '权', '逯', '盖', '益', '桓', '公', '万俟', '司马', '上官', '欧阳', '夏侯', '诸葛',
           '闻人', '东方', '赫连', '皇甫', '尉迟', '公羊', '澹台', '公冶', '宗政', '濮阳', '淳于', '单于',
           '太叔', '申屠', '公孙', '仲孙', '轩辕', '令狐', '钟离', '宇文', '长孙', '慕容', '鲜于', '闾丘',
           '司徒', '司空', '亓官', '司寇', '仉', '督', '子车', '颛孙', '端木', '巫马', '公西', '漆雕',
           '乐正', '壤驷', '公良', '拓跋', '夹谷', '宰父', '谷梁', '晋', '楚', '闫', '法', '汝', '鄢', '涂', '钦']

given_names = ['伟', '芳', '娜', '敏', '静', '丽', '强', '磊', '军', '洋', '勇', '艳', '杰', '娟', '涛', '明',
              '超', '秀英', '霞', '平', '刚', '桂英', '亮', '红', '丽', '勇', '桂兰', '强', '磊', '军', '洋',
              '勇', '艳', '杰', '娟', '涛', '明', '超', '秀英', '霞', '平', '刚', '桂英', '亮', '红', '丽',
              '勇', '桂兰', '强', '磊', '军', '洋', '勇', '艳', '杰', '娟', '涛', '明', '超', '秀英', '霞',
              '平', '刚', '桂英', '亮', '红', '丽', '勇', '桂兰', '强', '磊', '军', '洋', '勇', '艳', '杰',
              '娟', '涛', '明', '超', '秀英', '霞', '平', '刚', '桂英', '亮', '红', '丽', '勇', '桂兰']

# 专业列表
majors = ['计算机科学与技术', '软件工程', '网络工程', '信息安全', '数据科学与大数据技术', '人工智能', '物联网工程', '数字媒体技术',
          '电子信息工程', '通信工程', '电气工程及其自动化', '自动化', '测控技术与仪器', '机械设计制造及其自动化', '工业设计',
          '过程装备与控制工程', '机械工程', '车辆工程', '材料成型及控制工程', '材料科学与工程', '冶金工程', '金属材料工程',
          '无机非金属材料工程', '高分子材料与工程', '化学工程与技术', '制药工程', '轻化工程', '食品科学与工程', '食品质量与安全',
          '生物工程', '生物技术', '生物科学', '应用化学', '化学', '环境工程', '环境科学', '给排水科学与工程', '建筑环境与能源应用工程',
          '土木工程', '建筑学', '城乡规划', '风景园林', '工程管理', '工程造价', '水利水电工程', '水文与水资源工程',
          '港口航道与海岸工程', '测绘工程', '交通工程', '交通运输', '轮机工程', '航海技术', '船舶与海洋工程', '数学与应用数学',
          '信息与计算科学', '应用物理学', '应用统计学', '经济学', '国际经济与贸易', '金融学', '金融工程', '保险学', '投资学',
          '会计学', '财务管理', '人力资源管理', '工商管理', '市场营销', '物流管理', '电子商务', '旅游管理', '酒店管理',
          '英语', '俄语', '日语', '德语', '法语', '西班牙语', '阿拉伯语', '朝鲜语', '翻译', '商务英语', '新闻学', '广播电视学',
          '广告学', '传播学', '编辑出版学', '法学', '政治学与行政学', '国际政治', '外交学', '社会学', '社会工作', '民族学',
          '思想政治教育', '教育学', '科学教育', '人文教育', '学前教育', '小学教育', '特殊教育', '体育教育', '运动训练',
          '社会体育指导与管理', '武术与民族传统体育', '运动人体科学', '运动康复', '休闲体育', '临床医学', '基础医学',
          '预防医学', '中医学', '中西医临床医学', '药学', '中药学', '药物制剂', '护理学', '医学检验技术', '医学影像技术',
          '康复治疗学', '口腔医学', '医学影像学', '眼视光医学', '精神医学', '放射医学', '麻醉学', '医学实验技术',
          '历史学', '世界史', '考古学', '文物与博物馆学', '地理科学', '自然地理与资源环境', '人文地理与城乡规划', '地理信息科学',
          '大气科学', '应用气象学', '海洋科学', '地球物理学', '空间科学与技术', '地质学', '地球化学', '生物科学',
          '应用心理学', '统计学', '应用统计学', '理论与应用力学', '工程力学', '机械工程', '机械设计制造及其自动化',
          '材料科学与工程', '冶金工程', '能源与动力工程', '电气工程及其自动化', '电子信息工程', '电子科学与技术',
          '通信工程', '微电子科学与工程', '光电信息科学与工程', '信息工程', '自动化', '计算机科学与技术', '软件工程',
          '网络工程', '信息安全', '物联网工程', '数字媒体技术', '土木工程', '建筑环境与能源应用工程', '给排水科学与工程',
          '水利水电工程', '测绘工程', '化学工程与技术', '制药工程', '地质工程', '采矿工程', '石油工程', '纺织工程',
          '轻化工程', '包装工程', '印刷工程', '交通运输', '交通工程', '船舶与海洋工程', '航空航天工程', '武器系统与工程',
          '环境工程', '食品科学与工程', '建筑学', '城乡规划', '风景园林', '生物工程', '农业工程', '森林工程',
          '木材科学与工程', '家具设计与工程', '农业水利工程', '环境科学与工程', '生物医学工程', '食品质量与安全',
          '粮食工程', '乳品工程', '酿酒工程', '葡萄与葡萄酒工程', '食品营养与检验教育', '烹饪与营养教育', '安全工程',
          '生物技术', '数学与应用数学', '信息与计算科学', '应用物理学', '应用化学', '天文学', '地理科学', '大气科学',
          '海洋科学', '地球物理学', '地质学', '生物科学', '应用心理学', '统计学', '理论与应用力学', '工程力学']

# 班级列表
classes = ['计算机2021-1班', '计算机2021-2班', '计算机2022-1班', '计算机2022-2班', '计算机2023-1班', '计算机2023-2班',
          '软件2021-1班', '软件2021-2班', '软件2022-1班', '软件2022-2班', '软件2023-1班', '软件2023-2班',
          '网络2021-1班', '网络2021-2班', '网络2022-1班', '网络2022-2班', '网络2023-1班', '网络2023-2班',
          '电子2021-1班', '电子2021-2班', '电子2022-1班', '电子2022-2班', '电子2023-1班', '电子2023-2班',
          '机械2021-1班', '机械2021-2班', '机械2022-1班', '机械2022-2班', '机械2023-1班', '机械2023-2班',
          '土木2021-1班', '土木2021-2班', '土木2022-1班', '土木2022-2班', '土木2023-1班', '土木2023-2班',
          '化学2021-1班', '化学2021-2班', '化学2022-1班', '化学2022-2班', '化学2023-1班', '化学2023-2班',
          '生物2021-1班', '生物2021-2班', '生物2022-1班', '生物2022-2班', '生物2023-1班', '生物2023-2班',
          '数学2021-1班', '数学2021-2班', '数学2022-1班', '数学2022-2班', '数学2023-1班', '数学2023-2班',
          '物理2021-1班', '物理2021-2班', '物理2022-1班', '物理2022-2班', '物理2023-1班', '物理2023-2班',
          '英语2021-1班', '英语2021-2班', '英语2022-1班', '英语2022-2班', '英语2023-1班', '英语2023-2班',
          '中文2021-1班', '中文2021-2班', '中文2022-1班', '中文2022-2班', '中文2023-1班', '中文2023-2班']

# 生成随机姓名（2-3个汉字，指定复姓可有4个字）
def generate_name():
    # 有10%概率生成复姓（10:1的比例）
    if random.random() < 0.1:
        # 指定的复姓
        surname = random.choice(['欧阳', '上官', '司马', '东方', '南宫', '万俟', '夏侯', '诸葛', '尉迟', '令狐', '宇文', '公孙', '慕容'])
        # 复姓情况下，名字为2个字
        given_name = ''.join(random.choices(given_names, k=2))
    else:
        # 单姓（90%概率）
        surname = random.choice(surnames)
        # 单姓情况下，名字为1-2个字
        given_name = ''.join(random.choices(given_names, k=random.randint(1, 2)))
    return surname + given_name

# 生成随机学号
def generate_student_id():
    # 学号格式：年份(4位)+专业代码(2位)+序号(4位)
    year = random.randint(2020, 2024)
    major_code = random.randint(10, 99)
    serial_number = random.randint(1, 9999)
    return f"{year}{major_code:02d}{serial_number:04d}"

# 生成随机性别
def generate_gender():
    return random.choice(['男', '女'])

# 生成随机年龄
def generate_age():
    return random.randint(16, 25)

# 生成随机班级
def generate_class():
    return random.choice(classes)

# 生成随机专业
def generate_major():
    return random.choice(majors)

# 生成随机电话号码
def generate_phone():
    # 生成手机号码
    if random.choice([True, False]):
        prefix = random.choice(['138', '139', '158', '159', '188', '189', '177', '166'])
        suffix = ''.join(random.choices('0123456789', k=8))
        return f"{prefix}{suffix}"
    # 生成座机号码
    else:
        area_code = random.choice(['010', '021', '022', '023', '024', '025', '027', '028', '029'])
        number = ''.join(random.choices('0123456789', k=8))
        return f"{area_code}-{number}"

# 生成随机邮箱（使用英文前缀）
def generate_email(student_id):
    # 随机选择一个英文名作为邮箱前缀
    email_prefix = random.choice(english_names)
    # 有一定概率在英文名后添加数字
    if random.choice([True, False]):
        email_prefix += str(random.randint(1, 999))
    domains = ['@qq.com', '@163.com', '@126.com', '@gmail.com', '@hotmail.com', '@sina.com']
    return email_prefix + random.choice(domains)

# 生成随机入学日期
def generate_enrollment_date():
    # 入学日期在2020-09-01到当前日期之间
    start_date = datetime(2020, 9, 1)
    end_date = datetime.now()
    time_between = end_date - start_date
    days_between = time_between.days
    random_number_of_days = random.randrange(days_between)
    return start_date + timedelta(days=random_number_of_days)

# 生成随机学生数据
def generate_student_data(index):
    student_id = generate_student_id()
    name = generate_name()
    gender = generate_gender()
    age = generate_age()
    class_name = generate_class()
    major = generate_major()
    phone = generate_phone()
    email = generate_email(student_id)  # 修改为只使用学号作为参数
    enrollment_date = generate_enrollment_date()
    
    return (student_id, name, gender, age, class_name, major, phone, email, enrollment_date)

# 连接数据库并插入数据
def insert_student_data():
    if not mysql_available:
        print("MySQL连接器不可用，生成SQL文件...")
        generate_sql_file()
        return
        
    try:
        # 连接数据库
        print("正在连接数据库...")
        connection = mysql.connector.connect(**db_config)
        cursor = connection.cursor()
        print("数据库连接成功")
        
        # 插入1000条学生数据
        print("开始插入学生数据...")
        for i in range(1000):
            student_data = generate_student_data(i)
            insert_query = """
                INSERT INTO students (student_id, name, gender, age, class, major, phone, email, enrollment_date)
                VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s)
            """
            cursor.execute(insert_query, student_data)
            
            # 每100条记录提交一次
            if (i + 1) % 100 == 0:
                connection.commit()
                print(f"已插入 {i + 1} 条学生记录")
        
        # 最后提交
        connection.commit()
        print("成功插入1000条学生记录")
        
    except mysql.connector.Error as error:
        print(f"数据库错误: {error}")
        print("生成SQL文件作为替代方案...")
        generate_sql_file()
    except Exception as e:
        print(f"发生错误: {e}")
        print("生成SQL文件作为替代方案...")
        generate_sql_file()
    finally:
        if 'connection' in locals() and connection and connection.is_connected():
            cursor.close()
            connection.close()
            print("数据库连接已关闭")

# 生成SQL文件
def generate_sql_file():
    print("正在生成SQL文件...")
    try:
        # 使用UTF-8编码写入文件，避免中文乱码
        with open('student_data_1000.sql', 'w', encoding='utf-8') as f:
            f.write("-- 学生成绩管理系统 - 1000条学生测试数据\n")
            f.write("-- 生成时间: " + datetime.now().strftime("%Y-%m-%d %H:%M:%S") + "\n\n")
            
            for i in range(1000):
                student_data = generate_student_data(i)
                # 转义单引号
                escaped_data = []
                for item in student_data:
                    if isinstance(item, str):
                        escaped_item = item.replace("'", "''")
                        escaped_data.append(escaped_item)
                    else:
                        escaped_data.append(item)
                
                enrollment_date_str = student_data[8].strftime('%Y-%m-%d %H:%M:%S') if student_data[8] else 'NULL'
                
                insert_query = f"INSERT INTO students (student_id, name, gender, age, class, major, phone, email, enrollment_date) VALUES ('{escaped_data[0]}', '{escaped_data[1]}', '{escaped_data[2]}', {escaped_data[3]}, '{escaped_data[4]}', '{escaped_data[5]}', '{escaped_data[6]}', '{escaped_data[7]}', '{enrollment_date_str}');\n"
                f.write(insert_query)
                
                # 每100条记录添加一个注释
                if (i + 1) % 100 == 0:
                    f.write(f"-- 已生成 {i + 1} 条记录\n")
        
        print("SQL文件生成成功: student_data_1000.sql")
    except Exception as e:
        print(f"生成SQL文件时出错: {e}")

if __name__ == "__main__":
    print("开始生成1000条学生数据...")
    insert_student_data()
    print("数据生成完成")