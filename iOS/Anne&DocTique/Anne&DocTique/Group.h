//
//  Group.h
//  Anne&DocTique
//
//  Created by Kapi on 13/04/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Group : NSObject
@property (strong, nonatomic) NSString *author;
@property (strong, nonatomic) NSString *description;
@property (strong, nonatomic) NSDateFormatter *date;
@property (strong, nonatomic) NSString *voteplus;
@property (strong, nonatomic) NSString *votemoins;
@property (strong, nonatomic) NSString *favorite;
@end

