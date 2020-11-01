import PermissionType from './permissionType';

class UserInfo {
  username: string;
  role: string;
  issuedAt: Date;
  expires: Date;
  permissions: PermissionType[];

  constructor(decoded: any) {
    this.username = decoded.unique_name;
    this.role = decoded.role;
    this.issuedAt = new Date(decoded.iat * 1000);
    this.expires = new Date(decoded.exp * 1000);
    this.permissions = decoded.Permission.map(a => PermissionType[parseInt(a,0)]);

    console.log(this);
  }
}

export default UserInfo;
