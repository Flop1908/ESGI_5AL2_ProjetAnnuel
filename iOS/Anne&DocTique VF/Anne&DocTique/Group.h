//
//  Group.h
//  Anne&DocTique
//
//  Created by Kapi on 02/03/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Group : NSObject
//Group's element
@property (strong, nonatomic) NSString *Author;
@property (strong, nonatomic) NSString *Text;
@property (strong, nonatomic) NSString *Texte;
@property (strong, nonatomic) NSString *Id;
@property (strong, nonatomic) NSString *Date;
@property (strong, nonatomic) NSString *Type;
@property (strong, nonatomic) NSString *Nbcomments;
@property (strong, nonatomic) NSString *VotePlus;
@property (strong, nonatomic) NSString *VoteMoins;
@property (strong, nonatomic) NSString *Point;


@end
